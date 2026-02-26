using GameAPI.Data;
using GameAPI.DTOs.Auths;
using GameAPI.Models;
using GameAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(AppDbContext con, IConfiguration config)
        {
            _context = con;
            _config = config;
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null) throw new Exception($"Tidak ditemukan user dengan username {login.Username}");

            var isPsswordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (!isPsswordValid) throw new Exception("Username atau password salah!");
            return new AuthResponseDTO
            {
                Role = user.Role,
                Token = CreateToken(user),
                Username = user.Username
            };
        } 

        private string CreateToken(User user)
        {
            var jwt = _config.GetSection("Jwt");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                signingCredentials: creds,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwt["LifeTime"]))
                );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

    }
}
