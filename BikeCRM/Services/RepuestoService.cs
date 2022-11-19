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
    public class RepuestoServices : IRepuesto
    {


        private readonly OmanContext _context;

        public RepuestoServices(OmanContext context)
        {
            _context = context;
        }

        public async Task<List<Repuesto>> Get()
        {
            return await _context.Repuestos.ToListAsync();
        }
        public async Task<Repuesto> GetRepuestosByID(int id)
        {
            return await _context.Repuestos.FindAsync(id);
        }

        public async Task<Repuesto> PutRepuestos(int id, Repuesto repuesto)
        {
            if (id != repuesto.Id)
            {
                //return BadRequest();
            }

            _context.Entry(repuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }


            return await _context.Repuestos.FindAsync(id);
        }

        public async Task<Repuesto> PostRepuesto(Repuesto repuesto)
        {
            try
            {
                _context.Repuestos.Add(repuesto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return repuesto;
        }

    }
}
