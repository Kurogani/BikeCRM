using Microsoft.EntityFrameworkCore;
using BikeCRM.Controllers;
using BikeCRM.Data.Models;
using BikeCRM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BikeCRM.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly OmanContext _context;
        public UsuarioService(OmanContext context) => _context = context;

        public async Task<Usuario> GetUser(string usuario, string pass)
        {

            var query = (from a in _context.Usuarios
                         where a.Usuario1 == usuario
                         select a).FirstOrDefault();

            var validarpassword = ValidarContrasena(pass, query.Contrasena, query.Salt);

            if (validarpassword)
            {
                return query;

            }
            return null;

        }
        public async Task<Usuario> Register(string usuario, string pass, string name, int rol)
        {
            Usuario usertbl = new Usuario();
            var salt = CrearSalt();
            var passwordhashed = GenerarHash(pass, salt);
            var user = usuario;
            var password = pass;
            var nombre = name;

            usertbl.Usuario1 = user;
            usertbl.Contrasena = passwordhashed;
            usertbl.Salt = salt;
            usertbl.Nombre = nombre;
            usertbl.Rol = rol;
            await _context.Usuarios.AddAsync(usertbl);
            _context.SaveChanges();

            return usertbl;
        }

        public static string CrearSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[128 / 8];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerarHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool ValidarContrasena(string password, string stringHash, string salt)
        {
            string pass = password.ToString();
            string newHashedPin = GenerarHash(pass, salt);
            return newHashedPin.Equals(stringHash);
        }

        public async Task<Usuario> PutUsuario(string coduser, int rolcod)
        {

            var query = (from a in _context.Usuarios
                         where a.Usuario1 == coduser
                         select a).FirstOrDefault();
            try
            {
                var regis2 = _context.Usuarios.FromSqlRaw("UPDATE USUARIOS SET ROL =" + rolcod + " WHERE USUARIO ='" + coduser + "'").ToListAsync();

                await _context.SaveChangesAsync();
            }
            catch (Exception e) { }
            return query;
        }
    }
}

