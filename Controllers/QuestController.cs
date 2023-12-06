using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProustApp.Services;
using ProustApp.Domain;
using System.Linq;

namespace ProustApp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class QuestController : ControllerBase
{
    private readonly QuestsService _questService;

    public QuestController(QuestsService questsService)
    {
        _questService = questsService;
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var quest = await _questService.ReadAsync(id);
            if(quest==null) return NotFound("Data with id {id} not found.");
            
            return Ok(quest);
        }
        catch (Exception ex)
        {
            // _loger._LogError("");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Questionnaire newQuest)
    {
        try
        {
            await _questService.CreateAsync(newQuest);
            return CreatedAtAction(nameof(Get), new { id = newQuest.Id});

        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, Questionnaire updatedQuest)
    {
        var questToUpdate = await _questService.ReadAsync(id);

        if(questToUpdate == null)
        {
            return NotFound();
        }

        questToUpdate = updatedQuest;
        
        await _questService.UpdateAsync(id, questToUpdate);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var questToDelete = await _questService.ReadAsync(id);

        if(questToDelete == null)
        {
            return NotFound();
        }

        await _questService.DeleteAsync(id);
        
        return Ok();
    }
}