using BikeCRM.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeCRM.Interfaces
{
    public interface IClientes
    {

        public Task<List<Cliente>> Get();
        public Task<Cliente> GetClientesByID(int id);
        public Task<Cliente> PutClientes(int id, Cliente cliente);
        public bool ClienteExists(int id);
        Task<Cliente> PostClientes(Cliente cliente);


    }
}
