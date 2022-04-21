using System.Threading.Tasks;
using Games.Domain.Models;

namespace Games.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto request);
        Task<UserDto> Register(RegistrationDto request);
    }
}
