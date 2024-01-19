using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly string _dbConfig;

        public CarsRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<CarModel>> GetCars()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CarModel>(@"
                    SELECT 
                        id,
                        carname as Name,
                        car_date_release as DateRelease
                    FROM 
                        volksdatatable
                ");
            }
        }

        public async Task<CarModel> GetCarById(int id)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<CarModel>(@"
                    SELECT 
                        id,
                        carname as Name,
                        car_date_release as DateRelease
                    FROM 
                        volksdatatable
                    WHERE
                        id = @IdCar
                ", new {IdCar = id});
            }
        }

        public async Task<int> InsertCar(CarModel carModel)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<int>(@"
                    INSERT INTO volksdatatable
                        (id, carname, car_date_release)
                    VALUES
                        (nextval('volksdatatable_id_seq'::regclass), @Name, @DateRelease)
                    RETURNING id
                    
                ", new { Name = carModel.Name, DateRelease = carModel.DateRelease });
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                await conn.ExecuteAsync(@"
                    DELETE FROM public.volksdatatable
                    WHERE id=@Id;
                ", new { Id = id });
            }
        }

        public async Task<int> UpdateCar(CarModel carModel)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                await conn.ExecuteAsync(@"
                    UPDATE volksdatatable
                    SET carname=@Name, car_date_release=@DateRelease
                    WHERE id=@Id;
                ", new { Id = carModel.Id, Name = carModel.Name, DateRelease = carModel.DateRelease });
                return carModel.Id;
            }
        }
    }
}
