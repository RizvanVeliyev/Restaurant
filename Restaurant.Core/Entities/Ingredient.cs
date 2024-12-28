namespace Restaurant.Core.Entities
{
    public class Ingredient:BaseEntity
    {
        public string? Name { get; set; } 
        public ICollection<Product>? Products { get; set; }
    }
}
