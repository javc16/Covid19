using Covid19.AppServices;
using Covid19.Helpers;
using Covid19.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanoController : ControllerBase
    {
        public CiudadanoAppService _ciudadanoAppService { get; set; }
        public CiudadanoController(CiudadanoAppService ciudadanoAppService)
        {
            _ciudadanoAppService = ciudadanoAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Ciudadano>> GetAll()
        {
            var result = _ciudadanoAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _ciudadanoAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Ciudadano item)
        {
            return Ok(await _ciudadanoAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCiudadano(Ciudadano item)
        {
            return Ok(await _ciudadanoAppService.Put(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Ciudadano item)
        {
            return Ok(await _ciudadanoAppService.Delete(item));
        }
    }
}
