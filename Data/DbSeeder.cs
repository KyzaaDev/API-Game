using GameAPI.Models;

namespace GameAPI.Data
{
    public class DbSeeder
    {
        public static void seed(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Games.Any()) return;

            var initGames = new List<Game>
            {
            new Game {NamaGame = "The Witcher 3", Genre = "RPG", Harga = 350000m, Rating = 9.8 },
            new Game { NamaGame = "FIFA 23", Genre = "Sports", Harga = 750000m, Rating = 8.5 },
            new Game { NamaGame = "Call of Duty: Modern Warfare", Genre = "FPS", Harga = 900000m, Rating = 8.9 },
            new Game { NamaGame = "Minecraft", Genre = "Sandbox", Harga = 300000m, Rating = 9.5 },
            new Game { NamaGame = "Genshin Impact", Genre = "Action RPG", Harga = 0m, Rating = 8.7 },
            new Game { NamaGame = "Grand Theft Auto V", Genre = "Action", Harga = 450000m, Rating = 9.6 },
            new Game {  NamaGame = "Red Dead Redemption 2", Genre = "Adventure", Harga = 600000m, Rating = 9.7 },
            new Game {  NamaGame = "Valorant", Genre = "Tactical FPS", Harga = 0m, Rating = 8.3 },
            new Game {  NamaGame = "Elden Ring", Genre = "Action RPG", Harga = 850000m, Rating = 9.4 },
            new Game {  NamaGame = "Cyberpunk 2077", Genre = "RPG", Harga = 700000m, Rating = 8.1 }
            };

            context.Games.AddRange(initGames);
            context.SaveChanges();

    }
    }
}
