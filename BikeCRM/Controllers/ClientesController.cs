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
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _clientes;
        public ClientesController(IClientes clientes) => _clientes = clientes;

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _clientes.Get();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientesByID(int id)
        {
            var estado = await _clientes.GetClientesByID(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            await _clientes.PutClientes(id, cliente);
            return Ok(cliente);

        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostEstado(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientes.PostClientes(cliente);
            return Ok(cliente);
        }
    }
}
