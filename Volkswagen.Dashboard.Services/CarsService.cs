using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volkswagen.Dashboard.Repository;

namespace Volkswagen.Dashboard.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;

        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public int CreateCar(CarModel carModel)
        {
            //_listCars.Add(carModel);
            return carModel.Id;
        }

        public async Task<CarModel> GetCarById(int id) => await _carsRepository.GetCarById(id);

        public async Task<IEnumerable<CarModel>> GetCars() => await _carsRepository.GetCars();

        public async Task<int> InsertCar(CarModel carModel)
        {
            if(carModel.Id != 0)
                return await _carsRepository.UpdateCar(carModel);
            return await _carsRepository.InsertCar(carModel);
        }
        public async Task DeleteCar(int id) => await _carsRepository.DeleteCar(id);
    }
}
