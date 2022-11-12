using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Urna.COMMON.DTOS.Autenticacion;
using Urna.COMMON.DTOS.Elecciones;

namespace Urna.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }


        [HttpPost("registrar")]
        public async Task<ActionResult<AutenticacionDTO>> Registrar(UsuarioRequest request)
        {
            var usuario = new IdentityUser { UserName = request.NombreUsuario };
            var resultado = await _userManager.CreateAsync(usuario, request.Password);

            if (resultado.Succeeded)
            {
                return ConstruirToken(request);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AutenticacionDTO>> Login(UsuarioRequest request)
        {
            var resultado = await _signInManager.PasswordSignInAsync(request.NombreUsuario,
                request.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return ConstruirToken(request);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        private AutenticacionDTO ConstruirToken(UsuarioRequest request)
        {
            var claims = new List<Claim>()
            {
                new Claim("nombreUsuario", request.NombreUsuario),
                new Claim("otra cosa", "otro valor")
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["keyJwt"]));

            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMinutes(5);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: credenciales);

            return new AutenticacionDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion
            };
        }
    }
}
