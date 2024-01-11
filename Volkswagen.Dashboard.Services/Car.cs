using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Services
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRelease { get; set; }

        public static List<CarModel> GetCars()
        {
            return new List<CarModel>()
            {
                new CarModel() { Id = 1, Name = "Gol", DateRelease = DateTime.Now },
                new CarModel() { Id = 2, Name = "Saveiro", DateRelease = DateTime.Now },
                new CarModel() { Id = 3, Name = "Golf", DateRelease = DateTime.Now },
                new CarModel() { Id = 4, Name = "Santana", DateRelease = DateTime.Now },
                new CarModel() { Id = 5, Name = "Polo", DateRelease = DateTime.Now }
            };
        }
    }
}
