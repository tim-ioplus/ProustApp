using System.Collections.Generic;
using System.Linq;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestRepository 
{
    private object _dataConnection = null;
    public string Create(object quest)
    {
        var questId = "";

        if(quest != null)
        {
            questId = Guid.NewGuid().ToString();
            var sql = "Insert into quests";
            // todo send statement and read result
            bool success = false;
            if(!success)
            {
                questId = "";
            }
        }

        return questId;
    }
    public Questionnaire Read(int id)
    {
        Questionnaire? quest = null;
        
        if(_dataConnection== null && id == 1)
        {
            quest = GetMockData();
        }
        else if(id > 0)
        {
            var sql = "Select * from quests where id=" + id + ";";
            object result = null; 
            //@todo read from reader
            if(result != null)
            {
                var dataResult = new Dictionary<string, string>();
                //@todo parse dataResult from result
                quest = ParseResult(dataResult);
            }
        }

        return quest;
    }

    public bool Update(Questionnaire quest)
    {
        if(quest !=null)
        {
            var sql = "Update quests set answertext='" + quest + ",  where id= " + quest.Id + ";";
            // @todo send stament and read result
            return true;
        }

        return false;
    }

    public bool Delete(int id)
    {
        if(id >0)
        {
            var sql = "Delete from quests where id="+id+";";
            // @todo send statement and read result;
            return true;
        }

        return false;
    }

    
    public List<Questionnaire> List(int take = 0, int skip = 0)
    {
        var quests = new List<Questionnaire>();

        var sql = "Select * from quests ";
        
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
            quests = ParseResults(dataResults);
        }

        return quests;
    }

    public List<Questionnaire> ParseResults(List<object> dataResults)
    {
        var quests = new List<Questionnaire>();

        foreach(IDictionary<string, string> dataResult in dataResults)
        {
            var quest = ParseResult(dataResult);
            quests.Add(quest);
        }

        return quests;
    }

    public Questionnaire ParseResult(IDictionary<string, string> dataResult)
    {
        var quest = new Questionnaire();

        if(dataResult.Any())
        {
            //@todo parse Dictionary result to Quest Object
        }

        return quest;
    } 

    #region 'Data Helper'

    public Questionnaire GetMockData()
    {
        var quest = new Questionnaire
        {
            Id = 1,
            Author = "Marcel Proust",
            Topic = "",
            ResponseAuthor = "Marcel Proust",
            Dialogs = new Dictionary<string, string>
            {
                { "Your favourite virtue?", "The need to be loved; more precisely, the need to be caressed and spoiled much more than the need to be admired."},
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

        return quest;
    }

    #endregion
}