namespace Restaurant.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } // Məsələn: Yemək, İçki, Dessert
        public ICollection<Product> Products { get; set; }
    }
}
