using cloudstky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using cloudstky.Service.Interface;
using Microsoft.AspNetCore.Http;
using cloudstky.Services;

namespace cloudstky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

   

    
        IUserService _userService { get; }

        IJwtUtils _jwtUtils { get; set; }
        //    public List<TblAccount> _tblAccounts;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IJwtUtils jwtUtils)
        {
            _logger = logger;
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        public IActionResult Index()
        {
            //var tblAccount = _userService.GetAccount();

            //IEnumerable<TblAccount> test = tblAccount.Result;

            
            return View();
        }


        public IActionResult Login()
        {
            //  var tblAccount = _userService.GetAccount();

            //     IEnumerable<TblAccount> test = tblAccount.Result;
            MdlLogin mdlLogin = new MdlLogin();

            return View(mdlLogin);
        }

        const string SessionName = "Name";

        [HttpPost]
        public IActionResult Login(MdlLogin mdlLogin)
        {

                if (!ModelState.IsValid)
                {
                    return View(mdlLogin);
                }

           

            var tblAccount = _userService.GetAccount(mdlLogin).Result;

           string tokenkey = _jwtUtils.GenerateToken(tblAccount);


            if (tblAccount != null)
            {
                HttpContext.Session.SetString("JWToken", "Bearer " + tokenkey);         
                return RedirectToAction("ProdMange", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
           // HttpContext.Session.Remove("Name");
            HttpContext.Session.Clear();
            // var tblAccount = _userService.GetAccount();

            //     IEnumerable<TblAccount> test = tblAccount.Result;

            // Message = null;

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            // var tblAccount = _userService.GetAccount();

            //     IEnumerable<TblAccount> test = tblAccount.Result;
            MdlRegister mdlRegister = new MdlRegister();

            return View(mdlRegister);
        }

        [HttpPost]
        public IActionResult Register(MdlRegister  mdlRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(mdlRegister);
            }

            var state = _userService.SaveAccount(mdlRegister).Result;
            if(state == 1)
            {

                MdlLogin mdlLogin = new MdlLogin();
                mdlLogin.Username = mdlRegister.AccName;
                mdlLogin.Password = mdlLogin.Password;
                var tblAccount = _userService.GetAccount(mdlLogin).Result;

                string tokenkey = _jwtUtils.GenerateToken(tblAccount);


                if (tblAccount != null)
                {

        
                    HttpContext.Session.SetString("JWToken", "Bearer " + tokenkey);

                    return RedirectToAction("ProdMange", "Home");
                }

            }

            return View(mdlRegister);
        }


        [Authorize]
        public IActionResult ProdMange()
        {




            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {




            return View();
        }

        

        //public IActionResult ProdMange(string AccName)
        //{




        //    return View(AccName);
        //}




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
