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

namespace cloudstky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


    
        IUserService _userService { get; }

    //    public List<TblAccount> _tblAccounts;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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

            //     IEnumerable<TblAccount> test = tblAccount.Result;
            if(tblAccount != null)
            {

                //Message =  tblAccount.AccName ;
                HttpContext.Session.SetString(SessionName, tblAccount.AccName);
                return RedirectToAction("ProdMange", "Home", new { AccountRef = tblAccount.AccName });
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Name");
            //HttpContext.Session.Clear();
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
                HttpContext.Session.SetString(SessionName, mdlRegister.AccName);
                return RedirectToAction("ProdMange", "Home", new { AccountRef = mdlRegister.AccName });
            }

            return View(mdlRegister);
        }


        public IActionResult ProdMange(string AccName)
        {
            // var tblAccount = _userService.GetAccount();

            //     IEnumerable<TblAccount> test = tblAccount.Result;


            return View(AccName);
        }




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
