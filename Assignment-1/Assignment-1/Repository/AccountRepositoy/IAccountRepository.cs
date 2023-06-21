using Assignment_1.Models;
using Assignment_1.Models.DTO;

namespace Assignment_1.Repository.AccountRepositoy
{
    public interface IAccountRepository
    {
        bool Login(LoginVM loginVM);
        int Register(Register register);
    }
}
