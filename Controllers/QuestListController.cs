using Microsoft.AspNetCore.Mvc;
using ProustApp.Domain;
using ProustApp.Services;

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
        var quests = new QuestService().Get(1,1);

        var response = quests?.ToArray();
        return response;
        
    }
}