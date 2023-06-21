using Assignment_1.Context;
using Assignment_1.Models;
using Assignment_1.Models.DTO;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Repository.AccountRepositoy
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Register GetRgisterUserByEmail(string Email)
        {
            return _context.registers.Where(p => p.Email == Email).SingleOrDefault();
        }

        public bool Login(LoginVM loginVM)
        {
             return _context.registers.Any(x=>x.Email == loginVM.Email && x.Password==loginVM.Password);
        }

        public int Register(Register register)
        {
            var detail= GetRgisterUserByEmail(register.Email);
            if (detail==null)
            {
                _context.registers.Add(register);
            }
           
            return _context.SaveChanges();
        }
    }
}
