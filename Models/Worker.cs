namespace WebApplication1.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Salary { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public Worker(){}

        public Worker(string name, string specialization, int salary, int buildingId)
        {
            Name = name;
            Specialization = specialization;
            Salary = salary;
            BuildingId = buildingId;
        }
    }
}
