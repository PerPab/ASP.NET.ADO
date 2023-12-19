using ADO.MVC.ADM;
using ADO.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ADO.MVC.Controllers
{
    public class ArticuloController : Controller
    {

        ADMarticulo ADMarticulo = new ADMarticulo();
        public IActionResult Index()
        {
            return View(ADMarticulo.TraerTodos());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Articulo articulo)
        {
            ADMarticulo.Alta(articulo);
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            var articulo = ADMarticulo.TraerArticulo(id);
            return View(articulo);
        }

        public IActionResult Edit(int id)
        {
            var articulo = ADMarticulo.TraerArticulo(id);
            return View(articulo);
           
        }
        [HttpPost]
        public IActionResult Edit(int id, Articulo articulo)
        {
            ADMarticulo.Modificar(articulo);
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            var articulo = ADMarticulo.TraerArticulo(id);
            return View(articulo);

        }
        [HttpPost]
        public IActionResult Delete(int id, Articulo articulo)
        {
            ADMarticulo.Borrar(id);
            return RedirectToAction("index");

        }
    }
}
