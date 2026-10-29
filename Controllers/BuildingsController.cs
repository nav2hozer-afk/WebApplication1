using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
	public class BuildingsController : Controller
	{
		
		private readonly AppDbContext _context;
		public BuildingsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var buil = _context.resBuils.ToList();
			return View(buil);
		}

        [HttpGet]
        public IActionResult Index1()
        {
            var workers = _context.workers.ToList();
            return View(workers);
        }

        [HttpGet]
        public IActionResult Index2()
        {
            var materials = _context.materials.ToList();
            return View(materials);
        }
        [HttpGet]
        public IActionResult komer()
        {
            var materials = _context.buildings.ToList();
            return View(materials);
        }
        [HttpGet]
        public IActionResult resident()
        {
            var materials = _context.resBuils.ToList();
            return View(materials);
        }



        // Добавление жилого здания
        [HttpPost]
        public IActionResult AddBuilding(string Name, string Address, int Year, int Price, string buildingType, int? Apartments)
        {
            if (Apartments.HasValue && Apartments.Value > 0)
            {
                // Жилое здание
                var residentialBuilding = new ResidentialBuilding
                {
                    Name = Name,
                    Address = Address,
                    Year = Year,
                    Price = Price,
                    Apartments = Apartments.Value,
                };
                _context.resBuils.Add(residentialBuilding);
            }
            else
            {
                // Обычное (коммерческое) здание
                var building = new Building
                {
                    Name = Name,
                    Address = Address,
                    Year = Year,
                    Price = Price,
                };
                _context.buildings.Add(building);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Добавление рабочего (ассоциация)
        [HttpPost]
        public IActionResult AddWorker(string Name, string Specialization, int Salary, int BuildingId)
        {
            var worker = new Worker(Name, Specialization, Salary, BuildingId);
            _context.workers.Add(worker);
            _context.SaveChanges();
            return RedirectToAction("Index1");
        }

        // Добавление материала (отдельная таблица)
        [HttpPost]
        public IActionResult AddMaterial(string Name, string Type, int Quantity, int Price)
        {
            var material = new Material(Name, Type, Quantity, Price);
            _context.materials.Add(material);
            _context.SaveChanges();
            return RedirectToAction("Index2");
        }

        // Удаление здания
        [HttpPost]
        public IActionResult DeleteBuilding(int id)
        {
            var building = _context.buildings.Find(id);
            if (building != null)
            {
                _context.buildings.Remove(building);
                _context.SaveChanges();
            }
            return RedirectToAction("komer");
        }

        // Удаление рабочего
        [HttpPost]
        public IActionResult DeleteWorker(int id)
        {
            var worker = _context.workers.Find(id);
            if (worker != null)
            {
                _context.workers.Remove(worker);
                _context.SaveChanges();
            }
            return RedirectToAction("Index1");
        }

        // Удаление материала
        [HttpPost]
        public IActionResult DeleteMaterial(int id)
        {
            var material = _context.materials.Find(id);
            if (material != null)
            {
                _context.materials.Remove(material);
                _context.SaveChanges();
            }
            return RedirectToAction("Index2");
        }

        // Редактирование количества квартир (для жилых зданий)
        [HttpPost]
        public IActionResult UpdateApartments(string Name, int newApartments)
        {
            var building = _context.resBuils.FirstOrDefault(b => b.Name == Name);
            if (building != null)
            {
                building.Apartments = newApartments;
                _context.SaveChanges();
            }
            return RedirectToAction("resident");
        }

        // Поиск здания по названию
        [HttpGet]
        public IActionResult SearchBuilding(string Name_it)
        {
            var result = _context.resBuils.Where(b => b.Name == Name_it).ToList();
            return View("resident", result);
        }


        [HttpGet]
        public IActionResult SearchBuilding1(string Name_it)
        {
            var result = _context.buildings.Where(b => b.Name == Name_it).ToList();
            return View("komer", result);
        }

        // Редактирование зарплаты рабочего
        [HttpPost]
        public IActionResult UpdateSalary(string Name, int newSalary)
        {
            var worker = _context.workers.FirstOrDefault(w => w.Name == Name);
            if (worker != null)
            {
                worker.Salary = newSalary;
                _context.SaveChanges();
            }
            return RedirectToAction("Index1");
        }

	}
}
