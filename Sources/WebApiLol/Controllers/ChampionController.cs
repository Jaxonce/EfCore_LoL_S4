using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;
using WebApiLol.Converter;

namespace WebApiLol.Controllers;

[ApiController]
[Route("[controller]")]
public class ChampionController : ControllerBase
{
    private StubData.ChampionsManager ChampionsManager { get; set; } = new StubData.ChampionsManager(new StubData());

    private IChampionsManager _dataManager;
    private readonly ILogger<ChampionController> _logger;

    public ChampionController(IDataManager manager,ILogger<ChampionController> logger)
    {
        _dataManager = manager.ChampionsMgr;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ChampionPageDTO), 200)]
    public async Task<IActionResult> Get([FromQuery] int index = 0, int count = 10, string? name = "")
    {
        _logger.LogInformation($"methode Get de ControllerChampions appelée");
        int nbChampions = await _dataManager.GetNbItems();
        _logger.LogInformation($"Nombre de champions : {nbChampions}");
        var champs = (await _dataManager.GetItemsByName(name, index, int.MaxValue))
        .Where(champ => string.IsNullOrEmpty(name) || champ.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase))
        .Take(count)
        .Select(Model => Model.toDTO());

        var page = new ChampionPageDTO
        {
            Data = champs,
            Index = index,
            Count = champs.Count(),
            TotalCount = nbChampions
        };
        return Ok(page);
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
        Console.WriteLine("Le champion { " + champion.Name + " } avec pour bio { " + champion.Bio + " } a bien été ajouté");
        return Ok();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateChampion(string name, [FromBody] ChampionDTO champion)
    {
        var championSelected = await ChampionsManager.GetItemsByName(name, 0, await ChampionsManager.GetNbItemsByName(name), null);
        var existingChampion = championSelected.FirstOrDefault();
        if (existingChampion == null)
        {
            Console.WriteLine("Le champion { " + name + " } n'existe pas !");
            return NotFound();
        }
        var updatedChampion = champion.toModel();
        await ChampionsManager.UpdateItem(existingChampion, updatedChampion);
        if (updatedChampion.Bio == "string")
        {
            updatedChampion.Bio = "Aucune bio";
        }
        Console.WriteLine("Le champion { " + name + " } a été modifié en { " + updatedChampion.Name + " } avec pour bio { " + updatedChampion.Bio + " }");
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteChampion(string name)
    {
        var championSelected = await ChampionsManager.GetItemsByName(name, 0, await ChampionsManager.GetNbItemsByName(name), null);
        if (!await ChampionsManager.DeleteItem(championSelected.FirstOrDefault()))
        {
            Console.WriteLine("champion { " + name + " } non trouvé !");
            return NotFound();
        }
        Console.WriteLine("champion { " + name + " } supprimé");
        return Ok();
    }

}

