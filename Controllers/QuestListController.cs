using Microsoft.AspNetCore.Mvc;

namespace ProustApp.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestListController : ControllerBase
{
    private readonly ILogger<QuestListController> _logger;
    
    public QuestListController(ILogger<QuestListController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Quest> Get()
    {
        var questions = new List<string>()
        {
            "Your favourite virtue?", 
            "Your favourite qualities in a man?",
            "Your favourite qualities in a woman?",
            "Your chief characteristic?",
            "What you appreciate the most in your friends?",
            "Your main fault?",
            "Your favourite occupation?",
            "Your idea of happiness?",
            "Your idea of misery?",
            "If not yourself, who would you be?",
            "Where would you like to live?",
            "Your favourite colour?",
            "Your favourite flower?",
            "Your favourite bird?",
            "Your favourite prose authors?",
            "Your favourite poets?",
            "Your favourite heroes in fiction?",
            "Your favourite heroines in fiction?",
            "Your favourite painters and composers?"
        };
        
        var quests = new List<Quest>();

        int questionCount = 0;
        foreach(var question in questions)
        {
            var quest = new Quest();
            quest.Id = 1;
            quest.QuestionId = questionCount++;
            quest.QuestionAuthor = "Marcel Proust";
            quest.QuestionText = question;

            quest.AnswerId = questionCount;
            quest.AnswerAuthor = "You";
            quest.AnswerText = "";

            quests.Add(quest);
        }

        var response = quests.ToArray();
        return response;
    }
}