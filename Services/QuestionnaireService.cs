using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestionnaireService 
{
    public string Create(Questionnaire questionnaire)
    {
        var questionnaireId = "";

        if(questionnaire != null)
        {
            questionnaireId = new QuestionnaireRepository().Create(questionnaire);

        }

        return questionnaireId;
    }

    public Questionnaire? Read(int questionnaireId)
    {
        if (questionnaireId > 0)
        {
            Questionnaire? questionnaire = new QuestionnaireRepository().Read(questionnaireId);
            return questionnaire;
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
        var updated = false;

        if(questionnaire != null)
        {
            updated = new QuestionnaireRepository().Update(questionnaire);
        }

        return updated;
    }

    /// <summary>
    /// Deletes the Questionnaire with the given identifier 
    /// </summary>
    /// <param name="questionnaireId"></param>
    /// <returns>boolean indicating the success of the operation</returns>
    public bool Delete(int questionnaireId)
    {
        var deleted = false;

        if(questionnaireId > 0)
        {
            deleted = new QuestionnaireRepository().Delete(questionnaireId);
        }

        return deleted;
    }

    /// <summary>
    /// Lists the saved Questionnaires from the database.
    /// Showsonly Base Data, not Dialogs
    /// Needs to offer few different projections 
    /// </summary>
    /// <param name="filter">'list' for filled Questionnaire, 'choose' for questionnaires to fill out</param>
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
        if (questionnaireId < 1)
        {
            return null;
        }
        else
        {
            var quest = new QuestionnaireRepository().Read(questionnaireId);
            return quest;
        }        
    }
}