using GameAPI.Data;
using GameAPI.DTOs.Users;
using GameAPI.Models;
using GameAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext con)
        {
            _context = con;
        }

        public async Task<IEnumerable<UserResponseDTO?>> GetAllAsync()
        {
            var users = await _context.Users.Select(u => new UserResponseDTO
            {
                Nama = u.Nama,
                Username = u.Username,
                UserId = u.UserId,
                Email = u.Email,
                Alamat = u.Alamat,
                Role = u.Role,
            }).ToListAsync();

            if (!users.Any()) throw new Exception("Data ngga ada bang");

            return users;
        }

        public async Task<UserResponseDTO?> GetById(int id)
        {
            var userId = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (userId == null) throw new Exception($"Tidak ditemukan user dengan ID {id}!");
            return new UserResponseDTO
            {
                Nama = userId.Nama,
                Username = userId.Username,
                UserId = userId.UserId,
                Email = userId.Email,
                Alamat = userId.Alamat,
                Role = userId.Role,
            };
        }

        public async Task<UserResponseDTO> Create(UserCreateDTO data)
        {
            var newUser = new User
            {
                Username = data.Username,
                Role = data.Role,
                Alamat = data.Alamat,
                Email = data.Email,
                Nama = data.Nama,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserResponseDTO
            {
                Nama = newUser.Nama,
                Username = newUser.Username,
                UserId = newUser.UserId,
                Email = newUser.Email,
                Alamat = newUser.Alamat,
                Role = newUser.Role,
            };
        }
    }
}
