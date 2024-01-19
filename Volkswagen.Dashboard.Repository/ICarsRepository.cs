using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Repository
{
    public interface ICarsRepository
    {
        Task<IEnumerable<CarModel>> GetCars();
        Task<CarModel> GetCarById(int id);
        Task<int> InsertCar(CarModel carModel);
        Task DeleteCar(int id);
        Task<int> UpdateCar(CarModel carModel);
    }
}
