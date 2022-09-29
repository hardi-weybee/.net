using Exercise_3.Data;
using Exercise_3.Models;
using Exercise_3.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exercise_3.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _invoiceRepo = null;

        public InvoiceController(InvoiceRepository invoiceRepo, InvoiceContext context)
        {
            _invoiceRepo = invoiceRepo;
        }

        [HttpGet]
        public async Task<JsonResult> getProductByParty(int partyID)
        {
            var products = await _invoiceRepo.getProductByParty(partyID);
            return Json(products);
        }

        [HttpGet]
        public async Task<JsonResult> getRateByProduct(int productID)
        {
            var products = await _invoiceRepo.getRateByProduct(productID);
            return Json(products);
        }

        [HttpGet]
        public async Task<IActionResult> Display(int Pid, bool isSuccess = false, int grandTotal = 0 )
        {
            if (isSuccess == true)
            {
                ViewBag.ShowTable = await _invoiceRepo.DisplayTable(Pid);
                ViewBag.show = true;
                ViewBag.answer = grandTotal;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Display(int PartyId, InvoiceModel model)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _invoiceRepo.AddInvoice(model, PartyId);
            }
            return RedirectToAction("Display", new { Pid = PartyId, isSuccess = true, grandTotal = result });
        }

        public ViewResult Cancel()
        {
            return View(nameof(Display));
        }
    }
}