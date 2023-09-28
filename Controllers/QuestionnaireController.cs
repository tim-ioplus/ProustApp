using Microsoft.AspNetCore.Mvc;
using ProustApp.Services;
using ProustApp.Domain;
using System.Linq;

namespace ProustApp.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestionnaireController : ControllerBase
{
    private readonly ILogger<QuestionnaireController> _logger;
    
    public QuestionnaireController(ILogger<QuestionnaireController> logger)
    {
        _logger = logger;
    }

    // POST /questionnaires
    [HttpPost]
    public IActionResult Post([FromBody] Questionnaire newQuestionnaire)
    {
        if(newQuestionnaire?.Dialogs?.Count > 0)
        {
            var id = new QuestionnaireService().Create(newQuestionnaire);
            var ok = new OkObjectResult(id);
            return ok;
        }
        else
        {
            return NoContent();
        }        
    }

    // GET /questionnaires/id
    [HttpGet("{id}")]
    public Questionnaire Get(int id)
    {        
        var questionnaire = new QuestionnaireService().Get(id);
        
        return questionnaire;
    }

    // GET /questionnaires
    [HttpGet]
    public IEnumerable<Questionnaire> Get()
    {        
        var questionnaires = new QuestionnaireService().List();
        
        return questionnaires;
    }

    // GET /questionnaires/filter
    [HttpGet("{surveyfilter}")]
    public IEnumerable<Questionnaire> Get(string filter)
    {        
        var questionnaires = new QuestionnaireService().List(filter);
        
        return questionnaires;
    }

    // PUT /questionnaires
    [HttpPut]
    public IActionResult Update([FromBody] Questionnaire questionnaire)
    {
        var updated = new QuestionnaireService().Update(questionnaire);
        return new OkObjectResult(updated);
    }

    // DELETE /questionnaires/id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = new QuestionnaireService().Delete(id);
        return new OkObjectResult(deleted);
    }


    
    


}
