using System.Threading.Tasks;
using FunWebApi.Models;

namespace FunWebApi.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string Password);
        Task<User> Login(string username, string Password);
        Task<bool> UserExist(string username);

    }
}