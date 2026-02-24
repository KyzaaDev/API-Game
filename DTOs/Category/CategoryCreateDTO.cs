using System.ComponentModel.DataAnnotations;

namespace GameAPI.DTOs.Category
{
    public class CategoryCreateDTO
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
