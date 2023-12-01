using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestDataHelper
{
     #region 'Data Helper'
    
    public List<Questionnaire> Get()
    {
        var mockData = new List<Questionnaire>
        {
            GetMockData("1"),
            GetMockData("2"),
            GetMockData("3"),
            GetMockData("4")
        };

        return mockData; 
    }
    

    public Questionnaire GetMockData(string questionnaireId)
    {
        if(questionnaireId=="1") 
        {
            var questionnaire = new Questionnaire
            {
                Id = "1",
                Author = "Marcel Proust",
                Topic = "Original Proust Questionnaire",
                ResponseAuthor = "",
                Dialogs = new Dictionary<string, string>
                {
                    { "Your favourite virtue?",""},
                    { "Your favourite qualities in a man?", "" },
                    { "Your favourite qualities in a woman?", ""},
                    { "Your chief characteristic?", ""}, 
                    { "What you appreciate the most in your friends?", ""},
                    { "Your main fault?", ""},
                    { "Your favourite occupation?", ""},
                    { "Your idea of happiness?", ""},
                    { "Your idea of misery?", ""},
                    { "If not yourself, who would you be?", ""},
                    { "Where would you like to live?", ""},
                    { "Your favourite colour?", ""},
                    { "Your favourite flower?", ""},
                    { "Your favourite bird?", ""},
                    { "Your favourite prose authors?", ""},
                    { "Your favourite poets?", ""},
                    { "Your favourite heroes in fiction?", ""},
                    { "Your favourite heroines in fiction?", ""},
                    { "Your favourite painters and composers?", ""}
                }
            };  

            return questionnaire;
        }
        if(questionnaireId=="2") 
        {
            var questionnaire = new Questionnaire
            {
                Id = "2",
                Author = "Marcel Proust",
                Topic = "Original Proust Questionnaire",
                ResponseAuthor = "Marcel Proust",
                Dialogs = new Dictionary<string, string>
                {
                    { "Your favourite virtue?", 
                    "The need to be loved; more precisely, the need to be caressed and spoiled much more than the need to be admired."},
                    {  "Your favourite qualities in a man?", "Intelligence, moral sense." },
                    { "Your favourite qualities in a woman?", "Gentleness, naturalness, intelligence."},
                    { "Your chief characteristic?", ""}, // @todo possibility to intentionally left blank
                    { "What you appreciate the most in your friends?", "To have tenderness for me, if their personage is exquisite enough to render quite high the price of their tenderness."},
                    { "Your main fault?", "Not knowing, not being able to want "},
                    { "Your favourite occupation?", "Reading, daydreaming, writing verse, history, theater."},
                    { "Your idea of happiness?", "To live in contact with those I love, with the beauties of nature, with a quantity of books and music, and to have, within easy distance, a French theater. "},
                    { "Your idea of misery?", "Not to have known my mother or my grandmother."},
                    { "If not yourself, who would you be?", "Myself, as the people whom I admire would like me to be."},
                    { "Where would you like to live?", "A country where certain things that I should like would come true as though by magic, and where tenderness would always be reciprocated."},
                    { "Your favourite colour?", "The beauty is not in the colors, but in their harmony."},
                    { "Your favourite flower?", "All of them"},
                    { "Your favourite bird?", "The swallow."},
                    { "Your favourite prose authors?", "Currently, Anatole France,Pierre Loti., George Sand, Aug. Thierry."},
                    { "Your favourite poets?", "Baudelaire and Alfred de Vigny. Musset."},
                    { "Your favourite heroes in fiction?", "Hamlet, those of romance and poetry, those who are the expression of an ideal rather than an imitation of the real."},
                    { "Your favourite heroines in fiction?", "Bérénice, a woman of genius leading an ordinary life."},
                    { "Your favourite painters and composers?", "Beethoven, Wagner, Schumann, Meissonier, Mozart, Gounod."}
                }
            };  

            return questionnaire;
        }
        
        else if(questionnaireId=="3") 
        {
            var questionnaire = new Questionnaire
            {
                Id = "3",
                Author = "George Plimpton",
                Topic = "Asking the sea",
                ResponseAuthor = "",
                Dialogs = new Dictionary<string, string>
                {
                    { "How long can you actually be productive on a daily basis? How do you know when to stop?", ""},
                    { "Age is my alarm clock, why do old men wake so early? Is it to have one longer day?", ""},
                    { "What is pain?", ""}
                }
            };  

            return questionnaire;
        }
        else if(questionnaireId=="4") 
        {
            var questionnaire = new Questionnaire
            {
                Id = "4",
                Author = "George Plimpton",
                Topic = "Asking the sea",
                ResponseAuthor = "Ernest Hemmingway",
                Dialogs = new Dictionary<string, string>
                {
                    { "How long can you actually be productive on a daily basis? How do you know when to stop?", 
                    "That's something you have to learn about yourself. The important thing is to work every day. I work from about seven until about noon. Then I go fishing or swimming, or whatever I want. The best way is always to stop when you are going good. If you do that you'll never be stuck. And don't think or worry about it until you start to write again the next day. That way your subconscious will be working on it all the time, but if you worry about it, your brain will get tired before you start again. But work every day. No matter what has happened the day or night before, get up and bite on the nail."},
                    { "Age is my alarm clock, why do old men wake so early? Is it to have one longer day?", "I don’t know, all I know is that young boys sleep late and hard."},
                    { "What is pain?", "The most painful thing is losing yourself in the process of loving someone too much, and forgetting that you are special too."}
                }
            };  

            return questionnaire;
        }
        else
        {
            return null;
        }
    }

    #endregion
}