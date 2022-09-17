using cloudstky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using cloudstky.Service.Interface;

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
            var tblAccount = _userService.GetAccount();

            IEnumerable<TblAccount> test = tblAccount.Result;

            return View();
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
