using Microsoft.AspNetCore.Mvc;
using ProustApp.Services;
using ProustApp.Domain;
using System.Linq;

namespace ProustApp.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestController : ControllerBase
{
    private readonly ILogger<QuestController> _logger;
    
    public QuestController(ILogger<QuestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Questionnaire Get()
    {        
        var questionnaire = new QuestService().Get(1);
        
        #region  @todo remove when template loaded from DB 

        var questions = new Dictionary<string, string>(); 
        if(questionnaire != null && questionnaire.Dialogs != null)
        {
            foreach (var item in questionnaire.Dialogs)
            {
                questions.Add(item.Key, "");                
            }

            questionnaire.Dialogs = questions;
        }
        
        #endregion

        return questionnaire;
    }


    [HttpGet]
    public Questionnaire Get(int id)
    {        
        var questionnaire = new QuestService().Get(id);
        
        return questionnaire;
    }

    
    [HttpPost]
    public IActionResult Post([FromBody] Questionnaire questData)
    {
        if(questData?.Dialogs?.Count > 0)
        {
            var questDataId = new QuestService().Create(questData);
            return Ok("{questDataId:"+ questDataId +"}");
        }
        else
        {
            return NoContent();
        }        
    }
}

public class QuestData
{
    public List<Quest>? Quests {get; set;}
}