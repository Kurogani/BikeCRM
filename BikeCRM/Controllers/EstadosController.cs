using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeCRM.Data.Models;
using BikeCRM.Interfaces;

namespace BikeCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstados _estados;
        public EstadosController(IEstados estados) => _estados = estados;

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _estados.Get();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstadosByID(int id)
        {
            var estado = await _estados.GetEstadosByID(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstados(int id, Estado estado)
        {
            if (id != estado.Id)
            {
                return BadRequest();
            }
            await _estados.PutEstados(id, estado);
            return Ok(estado);

        }
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _estados.PostEstados(estado);
            return Ok(estado);
        }
    }
}
