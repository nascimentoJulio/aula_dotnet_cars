using Volkswagen.Dashboard.Repository;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Services
{
    public interface ICarsService
    {
        int CreateCar(CarModel carModel);
        Task<CarModel> GetCarById(int id);
        Task<IEnumerable<CarModel>> GetCars();
        Task<int> InsertCar(CarModel carModel);
        Task DeleteCar(int id);
    }
}
