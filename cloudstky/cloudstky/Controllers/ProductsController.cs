using cloudstky.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cloudstky.Controllers
{
    public class ProductsController : Controller
    {

        // GET: ProductsController
        private IProductsService _productsService { get; set; }

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productsService.Products();
            return View(products);
        }

        public async Task<ActionResult> Products()
        {
            var products = await _productsService.Products();
            return View(products);
        }
        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
