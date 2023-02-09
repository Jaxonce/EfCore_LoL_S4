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

    [HttpGet(Name = "GetChampion")]
    public ActionResult<IEnumerable<ChampionDTO>> Get()
    {
        return Ok(Enumerable.Range(1, 5).Select(index => new ChampionDTO
        {
            UniqueId = 0,
            Bio= "Test bio",
            Icon="Diamant",
            Name="Jax"
        })
        .ToArray());
    }

    [HttpPost]
    public async Task<IActionResult> AddRune(ChampionDTO champion)
    {
        var newChampion = champion.toModel();
        await ChampionsManager.AddItem(newChampion);
        return Ok(newChampion);
    }

}

