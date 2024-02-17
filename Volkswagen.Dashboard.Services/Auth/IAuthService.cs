using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volkswagen.Dashboard.Repository;

namespace Volkswagen.Dashboard.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
