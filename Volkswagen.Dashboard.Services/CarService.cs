using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Services
{
    public class CarService : ICarsService
    {
        private static readonly List<CarModel> _listCars = new List<CarModel>()
            {
                new CarModel() { Id = 1, Name = "Gol", DateRelease = DateTime.Now },
                new CarModel() { Id = 2, Name = "Saveiro", DateRelease = DateTime.Now },
                new CarModel() { Id = 3, Name = "Golf", DateRelease = DateTime.Now },
                new CarModel() { Id = 4, Name = "Santana", DateRelease = DateTime.Now },
                new CarModel() { Id = 5, Name = "Polo", DateRelease = DateTime.Now }
            };

        public int CreateCar(CarModel carModel)
        {
            _listCars.Add(carModel);
            return carModel.Id;
        }

        public CarModel GetCarById(int id) => GetCars().FirstOrDefault(car => car.Id == id);

        public List<CarModel> GetCars() => _listCars;
    }
}
