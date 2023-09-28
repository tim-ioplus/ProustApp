using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestionnaireService 
{
    public string Create(Questionnaire quests)
    {
        var questId = "";

        if(quests != null)
        {
            questId = new QuestionnaireRepository().Create(quests);

        }

        return questId;
    }

    public Questionnaire? Read(int questionnaireId)
    {
        var quest = new Questionnaire();

        if(questionnaireId > 0)
        {
            quest = new QuestionnaireRepository().Read(questionnaireId);
            return quest;
        }
        else
        {
            return null;
        }     
    } 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="questionnaire"></param>
    /// <returns>boolean indicating the success of the operation</returns>
    public bool Update(Questionnaire questionnaire)
    {
        var result = false;

        if(questionnaire != null)
        {
            result = new QuestionnaireRepository().Update(questionnaire);
        }

        return result;
    }

    /// <summary>
    /// Deletes the Questionnaire with the given identifier 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>boolean indicating the success of the operation</returns>
    public bool Delete(int id)
    {
        var result = false;

        if(id > 0)
        {
            result = new QuestionnaireRepository().Delete(id);
        }

        return result;
    }

    /// <summary>
    /// Lists the saved Questionnaires from the database.
    /// Needs to offer four different projections 
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    public IEnumerable<Questionnaire> List(string filter="", int take=0, int skip=0)
    {
        var quests = new QuestionnaireRepository().List(filter, take, skip);
        return quests;
    }
    
    public Questionnaire? Get(int questionnaireId = 1, int userId=1)
    {
        if (questionnaireId < 1) return null;

        var quest = new QuestionnaireRepository().Read(questionnaireId);
        return quest;        
    }
}