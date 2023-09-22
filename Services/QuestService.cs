using System.Collections.Generic;
using System.Linq;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestService 
{
    public string Create(Questionnaire quests)
    {
        var questId = "";

        if(quests != null)
        {
            questId = new QuestRepository().Create(quests);

        }

        return questId;
    }

    public Questionnaire? Read(int questionnaireId)
    {
        var quest = new Questionnaire();

        if(questionnaireId > 0)
        {
            quest = new QuestRepository().Read(questionnaireId);
            return quest;
        }
        else
        {
            return null;
        }     
    } 

    public bool Update(Questionnaire quest)
    {
        var result = false;

        if(quest != null)
        {
            result = new QuestRepository().Update(quest);
        }

        return result;
    }


    public bool Delete(int questId)
    {
        var result = false;

        if(questId > 0)
        {
            result = new QuestRepository().Delete(questId);
        }

        return result;
    }

    public List<Questionnaire> List(int take=0, int skip=0)
    {
        var quests = new QuestRepository().List(take, skip);
        return quests;
    }
    
    public Questionnaire? Get(int questionnaireId = 1, int userId=1)
    {
        if (questionnaireId < 1) return null;

        var quest = new QuestRepository().Read(questionnaireId);
        return quest;        
    }
}