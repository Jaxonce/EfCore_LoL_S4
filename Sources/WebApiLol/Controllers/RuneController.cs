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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await RunesManager.GetItems(0, await RunesManager.GetNbItems());
        return Ok(list.Select(rune => rune?.toDTO()));
    }

    [HttpGet("name")]
    public async Task<IActionResult> GetById(string name)
    {
        var runeSelected = await RunesManager.GetItemsByName(name, 0, await RunesManager.GetNbItemsByName(name), null);
        return Ok(runeSelected.Select(rune => rune?.toDTO()));
    }


    [HttpPost("addRune")]
    public async Task<IActionResult> AddRune(RuneDTO rune)
    {
        var newRune = rune.toModel();
        await RunesManager.AddItem(newRune);
        if (rune.Description == "string")
        {
            rune.Description = "No bio";
        }
        Console.WriteLine("Rune { " + rune.Name + " } with description { " + rune.Description + " } has been succesfully modified");
        return Ok(newRune);
    }

    [HttpPut("updateRune")]
    public async Task<IActionResult> UpdateRune(string name, RuneDTO rune)
    {
        var runeSelected = await RunesManager.GetItemsByName(name, 0, await RunesManager.GetNbItemsByName(name), null);
        var existingRune = runeSelected.FirstOrDefault();
        if (existingRune == null)
        {
            Console.WriteLine("La rune { " + name + " } doesn't exist !");
            return NotFound();
        }
        var updatedRune = rune.toModel();
        await RunesManager.UpdateItem(existingRune, updatedRune);
        if (rune.Description == "string")
        {
            rune.Description = "No bio";
        }
        Console.WriteLine("Rune { " + name + " } has been succesfully modified { " + updatedRune.Name + " } with description { " + rune.Description + " }");
        return Ok();
    }

    [HttpDelete("deleteRune")]
    public async Task<IActionResult> DeleteRune(string name)
    {
        var runeSelected = await RunesManager.GetItemsByName(name, 0, await RunesManager.GetNbItemsByName(name), null);
        if (!await RunesManager.DeleteItem(runeSelected.FirstOrDefault()))
        {
            Console.WriteLine("rune { " + name + " } not found !");
            return NotFound();
        }
        Console.WriteLine("rune { " + name + " } deleted");
        return Ok();
    }


}


