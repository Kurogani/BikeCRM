using BikeCRM.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeCRM.Interfaces
{
    public interface IEstados
    {

        public Task<List<Estado>> Get();
        public Task<Estado> GetEstadosByID(int id);
        public Task<Estado> PutEstados(int id, Estado estado);
        public bool EstadoExists(int id);
        Task<Estado> PostEstados(Estado estado);


    }
}
