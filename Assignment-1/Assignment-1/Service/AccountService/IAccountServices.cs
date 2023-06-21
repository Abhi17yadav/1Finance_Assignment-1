using Assignment_1.Models;
using Assignment_1.Models.DTO;

namespace Assignment_1.Service.AccountService
{
    public interface IAccountServices
    {
        bool Login(LoginVM loginVM);
        int Register(Register register);
    }
}
