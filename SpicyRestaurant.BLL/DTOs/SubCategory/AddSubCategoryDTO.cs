namespace SpicyRestaurant.BLL.DTOs.SubCategory
{
    public class AddSubCategoryDTO
    {
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Category Name must be between 2 and 50 characters.")]
        public string Name { get; set; } = null!;
        public string SubCategoryId { get; set; } = null!;
    }
}