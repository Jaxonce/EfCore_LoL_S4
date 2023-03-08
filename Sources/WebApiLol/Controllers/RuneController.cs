using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLol.Converter;
using Model;
using StubLib;
using static StubLib.StubData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLol.Controllers;

[ApiController]
[Route("[controller]")]
public class RuneController : ControllerBase
{
    private StubData.RunesManager RunesManager { get; set; } = new StubData.RunesManager(new StubData());
    private ILogger<RuneController> _logger;

    public RuneController(ILogger<RuneController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRune")]
    public ActionResult<IEnumerable<RuneDTO>> Get()
    {
        return Ok(Enumerable.Range(1,5).Select(index => new RuneDTO
        {
            Name = "La rune",
            Description = "test description"
        })
        .ToArray());
    }

  
    [HttpPost]
    public async Task<IActionResult> AddRune(RuneDTO rune)
    {
        var newRune = rune.toModel();
        await RunesManager.AddItem(newRune);
        return Ok(newRune);
    }

    
}


