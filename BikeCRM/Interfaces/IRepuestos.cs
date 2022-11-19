using BikeCRM.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeCRM.Interfaces
{
    public interface IRepuesto
    {

        public Task<List<Repuesto>> Get();
        public Task<Repuesto> GetRepuestosByID(int id);
        public Task<Repuesto> PutRepuestos(int id, Repuesto repuesto);
        Task<Repuesto> PostRepuesto(Repuesto repuesto);


    }
}
