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
    public class RepuetosController : ControllerBase
    {
        private readonly IRepuesto _repuesto;
        public RepuetosController(IRepuesto repuesto) => _repuesto = repuesto;

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repuesto>>> GetRepuestos()
        {
            return await _repuesto.Get();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repuesto>> GetRepuestosByID(int id)
        {
            var estado = await _repuesto.GetRepuestosByID(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuestos(int id, Repuesto repuesto)
        {
            if (id != repuesto.Id)
            {
                return BadRequest();
            }
            await _repuesto.PutRepuestos(id, repuesto);
            return Ok(repuesto);

        }
        [HttpPost]
        public async Task<ActionResult<Repuesto>> PostRepuesto(Repuesto repuesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repuesto.PostRepuesto(repuesto);
            return Ok(repuesto);
        }
    }
}
