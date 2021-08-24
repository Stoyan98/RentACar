using Microsoft.AspNetCore.Mvc;
using RentACar.Services.Cars;

namespace RentACar.Areas.Admin.Controllers
{
    public class CarsController : AdminController
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult All()
        {
            var cars = _carService
                .All(publicOnly: false, carsPerPage: int.MaxValue)
                .Cars;

            return View(cars);
        }

        public IActionResult ChangeVisibility(int id)
        {
            _carService.ChangeVisility(id);

            return RedirectToAction(nameof(All));
        }
    }
}
