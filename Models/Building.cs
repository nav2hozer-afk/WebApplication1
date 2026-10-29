using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string BuildingType { get; set; }

        public Building(){}
        public Building(string name, string address, int year, int price, string buildingType)
        {
            Name = name;
            Address = address;
            Year = year;
            Price = price;
            BuildingType = buildingType;
        }
    }
}
