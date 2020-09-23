namespace EShop
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Product()
        {

        }
        public Product(string name,string category,string description,decimal price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Name,10}       |{Description,10}     |{Price,8}";
        }
    }
}
