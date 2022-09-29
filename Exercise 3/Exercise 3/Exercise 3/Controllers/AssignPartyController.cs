using Exercise_3.Models;
using Exercise_3.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exercise_3.Controllers
{
    public class AssignPartyController : Controller
    {
        private readonly IAssignPartyRepository _assignRepo = null;

        public AssignPartyController(IAssignPartyRepository assignRepo)
        {
            _assignRepo = assignRepo;
        }
        

        public ViewResult GetAllAssignParty()
        {
            var data = _assignRepo.GetAllAssignParty();
            return View(data);
        }


        public ViewResult AddAssignParty(int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.ID = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignParty(AssignPartyModel model)
        {
            if(ModelState.IsValid)
            {
                int id = await _assignRepo.SaveAssignParty(model);
                if(id > 0)
                {
                    return RedirectToAction(nameof(AddAssignParty), new { isSuccess = 1, id =0 });
                }
                return RedirectToAction(nameof(AddAssignParty), new { isSuccess = 2 });
            }            
            return View("AddAssignParty");
        }


        [HttpGet("EditAssignParty/{id}/{partyname}/{proname}")]
        public ViewResult EditAssignParty([FromRoute] int id, [FromRoute] int partyname, [FromRoute] int proname, int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.ID = id;
            AssignPartyModel assignModel = new AssignPartyModel()
            {
                partyID = partyname,
                productID = proname
            };
            return View("AddAssignParty", assignModel);
        }

        [HttpPost("EditAssignParty/{id}/{partyname}/{proname}")]
        public async Task<IActionResult> EditAssignParty(AssignPartyModel model, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var suc = await _assignRepo.EditAssignParty(model, id);
                if (id > 0)
                {
                    return RedirectToAction(nameof(EditAssignParty), new { isSuccess = suc, AssignPartyId = id });
                }
                return RedirectToAction(nameof(EditAssignParty), new { isSuccess = 2 });
            }
            return View("AddAssignParty");
        }


        public async Task<IActionResult> DeleteAssignParty([FromRoute] int id)
        {
            bool isdeleted = await _assignRepo.DeleteAssignParty(id);
            if (isdeleted)
            {
                return RedirectToAction("GetAllAssignParty");
            }
            return null;
        }

        public async Task<JsonResult> getProductsNotAssigned(int partyID)
        {
            var product = Json(await _assignRepo.getProductsNotAssigned(partyID));
            return Json(product);
        }
    }
}