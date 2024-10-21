using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SupplierController : Controller
    {

        ISupplierHelper _supplierHelper;

        public SupplierController(ISupplierHelper supplierHelper)
        {
            this._supplierHelper = supplierHelper;
        }

        // GET: SupplierController
        public ActionResult Index() 
        {
            var lista = _supplierHelper.GetSuppliers();
            return View(lista);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            var supplier = _supplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierViewModel supplier)
        {
            try
            {
                _supplierHelper.Add(supplier);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el proveedor: " + ex.Message);
                return View(supplier);
            }
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = _supplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierViewModel supplier)
        {
            try
            {
                _supplierHelper.Update(supplier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = _supplierHelper.GetSupplier(id);
            return View(supplier);
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SupplierViewModel supplier)
        {
            try
            {
                _supplierHelper.Delete(supplier.SupplierId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
