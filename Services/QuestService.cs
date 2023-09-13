using System.Collections.Generic;
using System.Linq;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestService 
{
    public List<Quest>? Get(int questionnaireId = 1, int userId=1)
    {
        var quests = new List<Quest>();
        var questions = GetQuestions(questionnaireId);
        var answers = GetAnswers(questionnaireId, userId);

        if (questions==null) return null;

        foreach(var question in questions)
        {
            int answerId = question.Key;
            var answer = GetAnswer(questionnaireId, userId, answerId) ?? new KeyValuePair<int, string>(0,"");

            var quest = new Quest
            {
                AnswerAuthor = userId == 1 ? "Marcel Proust" : "",
                AnswerId = answer.Key,
                AnswerText = answer.Value,
                Id = questionnaireId,
                QuestionAuthor = userId == 1 ? "Marcel Proust" : "",
                QuestionId = question.Key,
                QuestionText = question.Value
            };

            quests.Add(quest);
        }

        return quests;
    }
    
    public Dictionary<int, string>? GetQuestions(int questionnaireId = 1)
    {
        if(questionnaireId==1)
        {
            var questions = new Dictionary<int, string>
            {
                { 1, "Your favourite virtue?" },
                { 2, "Your favourite qualities in a man?" },
                { 3, "Your favourite qualities in a woman?" },
                { 4, "Your chief characteristic?" },
                { 5, "What you appreciate the most in your friends?" },
                { 6, "Your main fault?" },
                { 7, "Your favourite occupation?" },
                { 8, "Your idea of happiness?" },
                { 9, "Your idea of misery?" },
                { 10, "If not yourself, who would you be?" },
                { 11, "Where would you like to live?" },
                { 12, "Your favourite colour?" },
                { 13, "Your favourite flower?" },
                { 14, "Your favourite bird?" },
                { 15, "Your favourite prose authors?" },
                { 16, "Your favourite poets?" },
                { 17, "Your favourite heroes in fiction?" },
                { 18, "Your favourite heroines in fiction?" },
                { 19, "Your favourite painters and composers?" }
            };

            return questions;
        }

        return null;
    }

    public KeyValuePair<int, string>? GetAnswer(int questionnaireId = 0, int userId=0, int answerId=0)
    {
        var answers = GetAnswers(questionnaireId, userId);
        if(answers == null) return null;

        KeyValuePair<int, string> answer = answers.SingleOrDefault(a => a.Key == answerId);
        return answer;
    }

    public Dictionary<int, string>? GetAnswers(int questionnaireId = 1, int userId=1)
    {
        if(questionnaireId==1 && userId==1)
        {
            var answers = new Dictionary<int, string>
            {
                { 1, "The need to be loved; more precisely, the need to be caressed and spoiled much more than the need to be admired." },
                { 2, "Intelligence, moral sense." },
                { 3, "Gentleness, naturalness, intelligence." },
                { 4, "" }, // @todo possibility to intentionally left blank
                { 5, "To have tenderness for me, if their personage is exquisite enough to render quite high the price of their tenderness." },
                { 6, "Not knowing, not being able to want " },
                { 7, "Reading, daydreaming, writing verse, history, theater." },
                { 8, "To live in contact with those I love, with the beauties of nature, with a quantity of books and music, and to have, within easy distance, a French theater. " },
                { 9, "Not to have known my mother or my grandmother." },
                { 10, "Myself, as the people whom I admire would like me to be." },
                { 11, "A country where certain things that I should like would come true as though by magic, and where tenderness would always be reciprocated." },
                { 12, "The beauty is not in the colors, but in their harmony." },
                { 13, "All of them" },
                { 14, "The swallow." },
                { 15, "Currently, Anatole France,Pierre Loti., George Sand, Aug. Thierry." },
                { 16, "Baudelaire and Alfred de Vigny. Musset." },
                { 17, "Hamlet, those of romance and poetry, those who are the expression of an ideal rather than an imitation of the real. " },
                { 18, "Bérénice, a woman of genius leading an ordinary life." },
                { 19, "Beethoven, Wagner, Schumann, Meissonier, Mozart, Gounod." }
            };

            return answers;
        }

        return null;
    }     
}