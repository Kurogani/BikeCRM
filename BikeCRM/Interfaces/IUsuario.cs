using BikeCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BikeCRM.Interfaces
{
    public interface IUsuario
    {
        Task<Usuario> GetUser(string usuario, string pass);
        Task<Usuario> Register(string usuario, string pass, string name, int rol);
        Task<Usuario> PutUsuario(string coduser, int rolcod);

    }
}
