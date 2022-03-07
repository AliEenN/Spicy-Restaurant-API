namespace SpicyRestaurant.BLL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
    }
}
