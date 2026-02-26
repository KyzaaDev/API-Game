using GameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Data
{
    public class DbSeeder
    {
        public static void seed(AppDbContext context)
        {
            context.Database.Migrate();
            if (context.Users.Any()) return;

            var initUsers = new List<User>
            {
                new User {Username = "KyzaaDev",Role = "Admin", Alamat = "Kyoto", Nama = "Dzaky RNF", Email = "kyzaadev@dump.com", Password = BCrypt.Net.BCrypt.HashPassword("Kyzaajaogamat")},
                new User {Username = "Kazuuu",Role = "User", Alamat = "Osaka", Nama = "Kazuha Nakamura", Email = "zuzuha@dump.com", Password = BCrypt.Net.BCrypt.HashPassword("zuzuhanaa")},
            };

            context.Users.AddRange(initUsers);
            context.SaveChanges();
    }
    }
}
