namespace WebApplication1.Models
{
    public class ResidentialBuilding : Building
    {
        public int Apartments { get; set; }

        public ResidentialBuilding() { }

        public ResidentialBuilding(string name, string address, int year, int price, string buildingType, int apartments)
            : base(name, address, year, price, buildingType)
        {
            Apartments = apartments;
        }
    }
}
