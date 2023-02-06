using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApiLol.Controllers;

[ApiController]
[Route("[controller]")]
public class ChampionController : ControllerBase
{

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
}

