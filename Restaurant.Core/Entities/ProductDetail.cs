using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class ProductDetail:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Ingredient>? Ingredients { get; set; } = [];
        public decimal Price { get; set; }
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
        public Language Language { get; set; } = null!;
        public int LanguageId { get; set; }




        //dile gore deyisen melumatlari, detailde yeni lang tanitdigimiz yerde saxlayirig, product ozunde yox,
        //yeni meselcun stringler textler dile gore deyisen melumatlardi onlari ,burda saxlayirig

    }
}
