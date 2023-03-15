using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StubLib;
using WebApiLol.Converter;
using static StubLib.StubData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLol.Controllers
{
    [Route("[controller]")]
    public class SkinController : Controller
    {
        private StubData.SkinsManager SkinsManager { get; set; } = new StubData.SkinsManager(new StubData());

        private readonly ILogger<SkinController> _logger;

        public SkinController(ILogger<SkinController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await SkinsManager.GetItems(0, await SkinsManager.GetNbItems());
            return Ok(list.Select(skin => skin?.toDTO()));
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetById(string name)
        {
            var skinSelected = await SkinsManager.GetItemsByName(name, 0, await SkinsManager.GetNbItemsByName(name), null);
            return Ok(skinSelected.Select(skin => skin?.toDTO()));
        }

        [HttpPost("addSkin")]
        public async Task<IActionResult> AddSkin(SkinDTO skin)
        {
            var newSkin = skin.toModel();
            await SkinsManager.AddItem(newSkin);
            if (skin.Description == "string")
            {
                skin.Description = "Aucune bio";
            }
            Console.WriteLine("Skin { " + skin.Name + " } with description { " + skin.Description + " } has been succesfully added");
            return Ok(newSkin);
        }

        [HttpPut("updateSkin")]
        public async Task<IActionResult> UpdateChampion(string name, SkinDTO skin)
        {
            var skinSelected = await SkinsManager.GetItemsByName(name, 0, await SkinsManager.GetNbItemsByName(name), null);
            var existingSkin = skinSelected.FirstOrDefault();
            if (existingSkin == null)
            {
                Console.WriteLine("Le skin { " + name + " } doesn't exist !");
                return NotFound();
            }

            var updatedSkin = skin.toModel();
            await SkinsManager.UpdateItem(existingSkin, updatedSkin);
            if (skin.Description == "string")
            {
                skin.Description = "Aucune bio";
            }
            Console.WriteLine("Skin { " + name + " } modified in " + " { " + updatedSkin.Name + " } with description { " + updatedSkin.Description + " }<");
            return Ok();
        }

        [HttpDelete("deleteSkin")]
        public async Task<IActionResult> DeleteChampion(string name)
        {
            var skinSelected = await SkinsManager.GetItemsByName(name, 0, await SkinsManager.GetNbItemsByName(name), null);
            if (!await SkinsManager.DeleteItem(skinSelected.FirstOrDefault()))
            {
                Console.WriteLine("skin { " + name + " } not found !");
                return NotFound();
            }
            Console.WriteLine("skin { " + name + " } deleted");
            return Ok();
        }

    }
}

