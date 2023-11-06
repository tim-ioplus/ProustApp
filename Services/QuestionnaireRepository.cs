using System.Collections.Generic;
using System.Linq;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestionnaireRepository 
{
    private object? _dataConnection = null;
    public string Create(Questionnaire questionnaire)
    {
        var questionnaireId = "";

        if(questionnaire != null)
        {
            questionnaireId = Guid.NewGuid().ToString();
            var sql = "Insert into quests";
            // todo send statement and read result
            bool success = false;
            if(!success)
            {
                questionnaireId = "";
            }
        }

        return questionnaireId;
    }
    public Questionnaire? Read(int questionnaireId)
    {
        Questionnaire? questionnaire = null;
        
        if(_dataConnection== null && questionnaireId == 1)
        {
            questionnaire = GetMockData();
        }
        else if(questionnaireId > 0)
        {
            var sql = "Select * from quests where id=" + questionnaireId + ";";
            object result = null; 
            //@todo read from reader
            if(result != null)
            {
                var dataResult = new Dictionary<string, string>();
                //@todo parse dataResult from result
                questionnaire = ParseResult(dataResult);
            }
        }

        return questionnaire;
    }

    public bool Update(Questionnaire questionnaire)
    {
        if(questionnaire !=null)
        {
            var sql = "Update quests set answertext='" + questionnaire + ",  where id= " + questionnaire.Id + ";";
            // @todo send stament and read result
            return true;
        }

        return false;
    }

    public bool Delete(int questionnaireId)
    {
        if(questionnaireId > 0)
        {
            var sql = "Delete from quests where id="+questionnaireId+";";
            // @todo send statement and read result;
            return true;
        }

        return false;
    }
    
    public List<Questionnaire> List(string filter = "", int take = 0, int skip = 0)
    {
        var questionnaires = new List<Questionnaire>();
        
        if(filter.Equals("unresponded"))
        {
            var q1 = new Questionnaire();
            q1.Id = 1;
            q1.Author = "Marcel Proust";
            q1.Topic = "The original Questionnaire";
            questionnaires.Add(q1);

            var q2 = new Questionnaire();
            q2.Id = 2;
            q2.Author = "Ernest Hemmingway";
            q2.Topic = "Asking the sea";
            questionnaires.Add(q2);

            return questionnaires;
        }

        var sql = "Select * from quests ";

        if(!string.IsNullOrEmpty(filter) && filter.Equals("surveys"))
        {
            sql += " where ResponseAuthor='' ";
        }
        
        if(take >0)
        {
            sql += "take=" + take + " ";
        }

        if(skip >0)
        {
            sql += "skip = " + skip + " ";            
        }
       
        sql += ";";

        
        var dataResults = new List<object>();
        // @todo send statement and read results

        if(dataResults.Any())
        {
            questionnaires = ParseResults(dataResults);
        }

        return questionnaires;
    }
    
    public List<Questionnaire> ParseResults(List<object> dataResults)
    {
        var questionnaires = new List<Questionnaire>();

        foreach(IDictionary<string, string> dataResult in dataResults)
        {
            var questionnaire = ParseResult(dataResult);
            questionnaires.Add(questionnaire);
        }

        return questionnaires;
    }

    public Questionnaire? ParseResult(IDictionary<string, string> dataResult)
    {
        var questionnaire = new Questionnaire();

        if(dataResult.Any())
        {
            //@todo parse Dictionary result to Quest Object
        }

        return questionnaire;
    } 

    #region 'Data Helper'

    public Questionnaire GetMockData()
    {
        var questionnaire = new Questionnaire
        {
            Id = 1,
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

    #endregion
}