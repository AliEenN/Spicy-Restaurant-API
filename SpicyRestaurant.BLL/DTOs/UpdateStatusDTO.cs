namespace SpicyRestaurant.BLL.DTOs
{
    public class UpdateStatusDTO
    {

        [Required]
        [MinLength(36)]
        [MaxLength(100)]
        public string Id { get; set; } = null!;

        [Required]
        public bool Active { get; set; }
    }
}