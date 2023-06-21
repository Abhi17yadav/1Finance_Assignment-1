using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Service.AccountService;
using AutoMapper;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        IMapper _mapper;
        public AccountController(IAccountServices accountServices,IMapper mapper)
        {
            this._accountServices = accountServices;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                int SuccessCount = _accountServices.Register(register);
                if (SuccessCount == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(register);
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Email", loginVM.Email);
                bool Detail= _accountServices.Login(loginVM);
                if(Detail==true)
                {
                    return RedirectToAction("Index","Product");
                }
                else
                {
                    return View(loginVM);
                }
            }
            return View(loginVM);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
