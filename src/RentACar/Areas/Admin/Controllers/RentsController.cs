using Microsoft.AspNetCore.Mvc;
using RentACar.Services.Rents;
using System.Linq;

namespace RentACar.Areas.Admin.Controllers
{
    public class RentsController : AdminController
    {
        private readonly IRentService _rentService;

        public RentsController(IRentService rentService)
        {
            _rentService = rentService;
        }

        public IActionResult All()
        {
            var rents = _rentService
                .GetAll();

            return View(rents);
        }

        public IActionResult Delete(int id)
        {
            _rentService.Remove(id);

            return RedirectToAction(nameof(All));
        }
    }
}
