namespace WebApplication1.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Material(){}

        public Material(string name, string type, int quantity, int price)
        {
            Name = name;
            Type = type;
            Quantity = quantity;
            Price = price;
        }
    }
}
