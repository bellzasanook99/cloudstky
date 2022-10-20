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
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace cloudstky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHostingEnvironment _hostingEnvironme;


             IUserService _userService { get; }
        IProductsService _productsService { get; }

        IJwtUtils _jwtUtils { get; set; }
        //    public List<TblAccount> _tblAccounts;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment environment, IUserService userService, IJwtUtils jwtUtils,IProductsService productsService)
        {
            _logger = logger;
            _userService = userService;
            _jwtUtils = jwtUtils;
            _productsService = productsService;
            _hostingEnvironme = environment;
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

         


            if (tblAccount != null)
            {
                string tokenkey = _jwtUtils.GenerateToken(tblAccount);
                HttpContext.Session.SetString("JWToken", "Bearer " + tokenkey);         
                return RedirectToAction("ProdMange", "Home");
            }
            else
            {
                ModelState.AddModelError("Error1", "No Register");
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
                mdlLogin.Password = mdlRegister.AccPwd;
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
            var mtbUnitType = _productsService.GetUnitTypes().Result;

            // MdlParam mdlParam = new MdlParam();
            //   mdlParam.mtbUnit = mtbUnitType;
            // ViewData["mtbUnitType"] = mtbUnitType;
            ViewBag.UnitData = mtbUnitType;
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ProdMange([FromForm]FileModel file)
        {
            bool Result = false;
            string Msg = "";
            try
            {
                if (file.FromFile != null)
                {
                    Guid id = Guid.NewGuid();

                    string webRootPath = _hostingEnvironme.WebRootPath + "\\" + file.AccName;
                    string contentRootPath = _hostingEnvironme.ContentRootPath;

                    if (!Directory.Exists(webRootPath))
                    {
                        Directory.CreateDirectory(webRootPath);
                    }
                    string path = "";
                    path = Path.Combine(webRootPath, id.ToString());
                    //var path = Path.Combine(pathx, id.ToString());
                    foreach (IFormFile formFile in file.FromFile)
                    {
                        using (Stream stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                Result = true;
            }
            catch(Exception ex) { }
            //var tblProduct = (TblProduct)file.tblProduct;

            return Json(new { Result, Msg });
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
