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
    public class EstadoServices : IEstados
    {


        private readonly OmanContext _context;

        public EstadoServices(OmanContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> Get()
        {
            return await _context.Estados.ToListAsync();
        }
        public async Task<Estado> GetEstadosByID(int id)
        {
            return await _context.Estados.FindAsync(id);
        }

        public async Task<Estado> PutEstados(int id, Estado estado)
        {
            if (id != estado.Id)
            {
                //return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }


            return await _context.Estados.FindAsync(id);
        }

        public async Task<Estado> PostEstados(Estado estado)
        {
            try
            {
                _context.Estados.Add(estado);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return estado;
        }

        public bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }
    }
}
