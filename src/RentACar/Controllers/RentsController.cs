using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.Rents;
using RentACar.Services.Rents;

namespace RentACar.Controllers
{
    public class RentsController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IMapper _mapper;

        public RentsController(IRentService rentService, IMapper mapper)
        {
            _rentService = rentService;
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
            var rentTest = rent;

            return View();
        }
    }
}
