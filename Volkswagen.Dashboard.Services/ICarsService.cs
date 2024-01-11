namespace Volkswagen.Dashboard.Services
{
    public interface ICarsService
    {
        int CreateCar(CarModel carModel);
        CarModel GetCarById(int id);
        List<CarModel> GetCars();
    }
}
