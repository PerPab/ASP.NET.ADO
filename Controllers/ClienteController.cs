using ADO.MVC.ADM;
using ADO.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.MVC.Controllers
{
    public class ClienteController : Controller
    {

        ADMcliente ADMcliente = new ADMcliente();
        // GET: ClienteController
        public ActionResult Index()
        {
            return View(ADMcliente.TraerTodos());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View(ADMcliente.TraerCliente(id));
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente Collection)
        {
            try
            {
                ADMcliente.Alta(Collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ADMcliente.TraerCliente(id));

        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente collection)
        {
            try
            {
                ADMcliente.Modificar(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ADMcliente.TraerCliente(id));
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ADMcliente.Borrar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
