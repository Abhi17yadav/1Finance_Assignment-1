using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Repository.AccountRepositoy;

namespace Assignment_1.Service.AccountService
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        public AccountServices(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public bool Login(LoginVM loginVM)
        {
            return _accountRepository.Login(loginVM);
        }

        public int Register(Register register)
        {
            return _accountRepository.Register(register);
        }
    }
}
