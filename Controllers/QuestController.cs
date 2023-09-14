using Microsoft.AspNetCore.Mvc;
using ProustApp.Services;
using ProustApp.Domain;

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
    public IEnumerable<Quest> Get()
    {        
        var quests = new List<Quest>();
        var questions = new QuestService().GetQuestions(1);
        
        int questionCount = 0;
        foreach(var question in questions)
        {
            var quest = new Quest
            {
                Id = 1,
                QuestionId = question.Key,
                QuestionAuthor = "Marcel Proust",
                QuestionText = question.Value,

                AnswerId = questionCount,
                AnswerAuthor = "You",
                AnswerText = ""
            };

            quests.Add(quest);
        }

        var response = quests.ToArray();
        return response;
    }

    
    [HttpPost]
    public IActionResult Create([FromForm] Quest quest)
    {
        return Ok("Quest");
    }


}