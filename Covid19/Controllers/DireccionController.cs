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
    public class DireccionController : ControllerBase
    {
        public DireccionAppService _direccionAppService { get; set; }
        public DireccionController(DireccionAppService direccionAppService)
        {
            _direccionAppService = direccionAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Direccion>> GetAll()
        {
            var result = _direccionAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _direccionAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Direccion item)
        {
            return Ok(await _direccionAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(Direccion item)
        {
            return Ok(await _direccionAppService.Put(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Direccion item)
        {
            return Ok(await _direccionAppService.Delete(item));
        }
    }
}
