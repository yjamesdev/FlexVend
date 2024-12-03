using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Microsoft.Extensions.Configuration;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DB _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(DB dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Auth model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Verificar la contraseña con un hash (si es necesario)
            if (user.Password != model.Password)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Crear una lista de claims (reclamos de la autenticación)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Username", user.Username),
                new Claim("Status", user.status.ToString())
            };

            // Agregar el rol del usuario
            claims.Add(new Claim(ClaimTypes.Role, user.RoleId.ToString()));

            // Crear el token JWT
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256
                )
            );

            // Retornar el token en la respuesta
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user = new { name = user.Username, role = user.RoleId.ToString(), status = user.status.ToString() }
            });
        }

    }
}
