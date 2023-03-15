using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StubLib;
using WebApiLol.Converter;

namespace WebApiLol.Controllers;

[ApiController]
[Route("[controller]")]
public class ChampionController : ControllerBase
{
    private StubData.ChampionsManager ChampionsManager { get; set; } = new StubData.ChampionsManager(new StubData());

    private readonly ILogger<ChampionController> _logger;

    public ChampionController(ILogger<ChampionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await ChampionsManager.GetItems(0, await ChampionsManager.GetNbItems());
        return Ok(list.Select(champion => champion?.toDTO()));
    }

    [HttpGet("name")]
    public async Task<IActionResult> GetById(string name)
    {
        var championSelected = await ChampionsManager.GetItemsByName(name, 0, await ChampionsManager.GetNbItemsByName(name), null);
        return Ok(championSelected.Select(c => c?.toDTO()));
    }

    [HttpPost("addChampion")]
    public async Task<IActionResult> AddChampion([FromBody] ChampionDTO champion)
    {
        var newChampion = champion.toModel();
        await ChampionsManager.AddItem(newChampion);
        if (champion.Bio == "string")
        {
            champion.Bio = "Aucune bio";
        }
        Console.WriteLine("Champion { " + champion.Name + " } with bio { " + champion.Bio + " } has been succesfully added");
        return Ok();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateChampion(string name, [FromBody] ChampionDTO champion)
    {
        var championSelected = await ChampionsManager.GetItemsByName(name, 0, await ChampionsManager.GetNbItemsByName(name), null);
        var existingChampion = championSelected.FirstOrDefault();
        if (existingChampion == null)
        {
            Console.WriteLine("Champion { " + name + " } doesn't exist !");
            return NotFound();
        }
        var updatedChampion = champion.toModel();
        await ChampionsManager.UpdateItem(existingChampion, updatedChampion);
        if (updatedChampion.Bio == "string")
        {
            updatedChampion.Bio = "Aucune bio";
        }
        Console.WriteLine("Champion { " + name + " } has been modified in { " + updatedChampion.Name + " } with bio { " + updatedChampion.Bio + " }");
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteChampion(string name)
    {
        var championSelected = await ChampionsManager.GetItemsByName(name, 0, await ChampionsManager.GetNbItemsByName(name), null);
        if (!await ChampionsManager.DeleteItem(championSelected.FirstOrDefault()))
        {
            Console.WriteLine("champion { " + name + " } not found !");
            return NotFound();
        }
        Console.WriteLine("champion { " + name + " } deleted");
        return Ok();
    }

}

