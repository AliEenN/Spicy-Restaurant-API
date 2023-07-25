namespace SpicyRestaurant.BLL.Data.Entities
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = null!;

        [MaxLength(50), MinLength(2)]
        public string? Name { get; set; }
        public bool Active { get; set; } = true;
    }
}