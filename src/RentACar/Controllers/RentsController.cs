using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Infrastructure.Extensions;
using RentACar.Models.Rents;
using RentACar.Services.Cars;
using RentACar.Services.Rents;

namespace RentACar.Controllers
{
    using static WebConstants;

    public class RentsController : Controller
    {
        private readonly IRentService _rentService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public RentsController(IRentService rentService, ICarService carService, IMapper mapper)
        {
            _rentService = rentService;
            _carService = carService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult NewRent(int id)
        {
            var rentACar = new RentFormModel
            {
                CarId = id
            };

            return View(rentACar);
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewRent(RentFormModel rent)
        {
            if (!ModelState.IsValid)
            {
                return View(rent);
            }

            var car = _carService.Details(rent.CarId);

            TempData[GlobalMessageKey] = $"You rent a car ({car.Brand} {car.Model} - {car.Year}) successfully from {rent.StartDate.ToShortDateString()} to {rent.EndDate.ToShortDateString()}";

            return RedirectToAction("Index", "Home");
        }
    }
}
