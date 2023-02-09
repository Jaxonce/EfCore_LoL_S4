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

        [HttpGet(Name = "GetSkin")]
        public ActionResult<IEnumerable<SkinDTO>> Get()
        {
            return Ok(Enumerable.Range(1, 5).Select(index => new SkinDTO
            {
                Name = "Skin tah les fou",
                Description ="Skin assez limité et sorti le 23/02/2022",
                Icon = "je sais pas ce que c'est un icon",
                Price = 25.0f
            })
            .ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> AddSkin(SkinDTO skin)
        {
            var newSkin = skin.toModel();
            await SkinsManager.AddItem(newSkin);
            return Ok(newSkin);
        }

    }
}

