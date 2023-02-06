using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLol.Controllers
{
    [Route("[controller]")]
    public class SkillsController : Controller
    {
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ILogger<SkillsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSkills")]
        public ActionResult<IEnumerable<SkillsDTO>> Get()
        {
            return Ok(Enumerable.Range(1, 5).Select(index => new SkillsDTO
            {
                Name = "Rapias",
                Description = "Empeche de donner son argent à n'importe qui"
            })
            .ToArray());
        }
    }
}

