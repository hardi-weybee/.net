using Exercise_3.Models;
using Exercise_3.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exercise_3.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyRepository _partyRepo = null;

        public PartyController(IPartyRepository partyRepo)
        {
            _partyRepo = partyRepo;
        }

        
        public async Task<ViewResult> GetAllParty()
        {
            var data = await _partyRepo.GetAllParty();
            return View(data);
        }


        public ViewResult AddParty(int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.id = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddParty(PartyModel model)
        {
            if (ModelState.IsValid)
            {
                int id = await _partyRepo.SaveParty(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddParty), new { isSuccess = 1, id = 0 });
                }
                return RedirectToAction(nameof(AddParty), new { isSuccess = 2 });
            }
            return View("AddParty");
        }


        [HttpGet("EditParty/{id}")]
        public ViewResult EditParty([FromRoute]int id, string name, int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.id = id;
            ViewBag.PartyName = name;
            PartyModel partyModel = new PartyModel()
            {
                ID = id,
                PartyName = name
            };
            return View("AddParty", partyModel);
        }

        [HttpPost("EditParty/{id}")]
        public async Task<IActionResult> EditParty(PartyModel model, [FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                var suc = await _partyRepo.EditParty(model, id);
                if (id > 0)
                {
                    return RedirectToAction(nameof(EditParty) , new { isSuccess = suc, PartyId = id, name=model.PartyName });
                }
                return RedirectToAction(nameof(EditParty), new { isSuccess = 2 });
            }
            return View("AddParty");
        }

        
        public async Task<IActionResult> DeleteParty([FromRoute] int id)
        {
            bool isdeleted =  await _partyRepo.DeleteParty(id);
            if (isdeleted)
            {
                return RedirectToAction(nameof(GetAllParty));
            }
            return null;
        }
    }
}