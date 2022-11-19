using BikeCRM.Controllers;
using BikeCRM.Data.Models;
using BikeCRM.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace BikeCRM.Services
{
    public class ClienteServices : IClientes
    {


        private readonly OmanContext _context;

        public ClienteServices(OmanContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> GetClientesByID(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> PutClientes(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                //return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }


            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> PostClientes(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return cliente;
        }

        public bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
