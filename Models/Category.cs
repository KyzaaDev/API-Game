namespace GameAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
