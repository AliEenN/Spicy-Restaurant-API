namespace SpicyRestaurant.BLL.Data.Entities
{
    public class SubCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = null!;

        [MaxLength(100), MinLength(2)]
        public string? Name { get; set; }

        public string CategoryId { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}