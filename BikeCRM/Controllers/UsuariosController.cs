using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeCRM.Data.Models;
using BikeCRM.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Newtonsoft.Json;
using BikeCRM.Data.Models;

namespace BikeCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuarioService;
        public UsuariosController(IUsuario usuarios) => _usuarioService = usuarios;


        [HttpPost]
        [Route("Register/{usuario}/{pass}/{name}/{rol}")]

        public async Task<IActionResult> Register(string usuario, string pass, string name, int rol)
        {
            var insertemp = await _usuarioService.Register(usuario, pass, name, rol);
            return Ok(insertemp);
        }

        [HttpGet]
        [Route("GetUser/{usuario}/{pass}")]

        public async Task<IActionResult> GetUser(string usuario, string pass)
        {
            var user = await _usuarioService.GetUser(usuario, pass);
            if (user.Usuario1 == null)
            {
                return BadRequest(new { message = "Usuario o contrase;a incorrectos" });

            }
            if (user.Usuario1 == usuario)
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var resultado = new { Usuario = user, Token = tokenString };
                return Ok(resultado);

            }

            else
            {
                return Unauthorized();
            }

        }

        [HttpPut]
        [Route("PutUsuario/{coduser}/{rolcod}")]

        public async Task<IActionResult> PutUsuario(string coduser, int rolcod)
        {

            var fac = await _usuarioService.PutUsuario(coduser, rolcod);
            return Ok(fac);
        }
    }
}
