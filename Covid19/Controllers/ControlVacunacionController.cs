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
    public class ControlVacunacionController : ControllerBase
    {
        public ControlVacunacionAppService _controlVacunacionAppService { get; set; }
        public ControlVacunacionController(ControlVacunacionAppService controlVacunacionAppService)
        {
            _controlVacunacionAppService = controlVacunacionAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ControlVacunas>> GetAll()
        {
            var result = _controlVacunacionAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _controlVacunacionAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ControlVacunas item)
        {
            return Ok(await _controlVacunacionAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(ControlVacunas item)
        {
            return Ok(await _controlVacunacionAppService.Put(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(ControlVacunas item)
        {
            return Ok(await _controlVacunacionAppService.Delete(item));
        }
    }
}
