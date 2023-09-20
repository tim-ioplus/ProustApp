using System.Collections.Generic;
using System.Linq;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestRepository 
{
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
    public Quest Read(int id)
    {
        Quest? quest = null;

        if(id > 0)
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

    public bool Update(Quest quest)
    {
        if(quest !=null)
        {
            var sql = "Update quests set answertext='" + quest.AnswerText + ",  where id= " + quest.Id + ";";
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

    
    public List<Quest> List(int take = 0, int skip = 0)
    {
        var quests = new List<Quest>();

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

    public List<Quest> ParseResults(List<object> dataResults)
    {
        var quests = new List<Quest>();

        foreach(IDictionary<string, string> dataResult in dataResults)
        {
            var quest = ParseResult(dataResult);
            quests.Add(quest);
        }

        return quests;
    }

    public Quest ParseResult(IDictionary<string, string> dataResult)
    {
        var quest = new Quest();

        if(dataResult.Any())
        {
            //@todo parse Dictionary result to Quest Object
        }

        return quest;
    } 
}