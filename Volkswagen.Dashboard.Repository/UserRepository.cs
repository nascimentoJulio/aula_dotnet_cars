using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkswagen.Dashboard.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dbConfig;

        public UserRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }
        public async Task<bool> ExistWithEmail(string email)
        {
            return await GetUserByEmail(email) != null;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<UserModel>(@"
                    SELECT 
                        email, username, password
                    FROM 
                        users
                    WHERE
                        email = @Email
                ", new { Email = email });
            }
        }

        public async Task InsertUser(string email, string username, string password)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                var result = await conn.ExecuteAsync(@"
                    INSERT INTO public.users
                        (id, username, email, ""password"", created_at)
                    VALUES(nextval('users_id_seq'::regclass), @Username, @Email, @Password, CURRENT_TIMESTAMP);
                ", new { Username = username, Email = email, Password = password });
            }
        }
    }
}
