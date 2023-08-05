namespace SpicyRestaurant.BLL.DTOs.Category
{
    public class EditCategoryDTO
    {

        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}