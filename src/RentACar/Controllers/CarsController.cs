using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RentACar.Services.Cars;
using RentACar.Services.Dealers;
using RentACar.Models.Cars;
using Microsoft.AspNetCore.Authorization;
using RentACar.Infrastructure.Extensions;
using RentACar.Services.Comments;
using RentACar.Models.Comments;

namespace RentACar.Controllers
{
    using static WebConstants;

    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IDealerService _dealerService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IDealerService dealerService, ICommentService commentService, IMapper mapper)
        {
            _carService = carService;
            _dealerService = dealerService;
            _commentService = commentService;
            _mapper = mapper;
        }

        public IActionResult All([FromQuery] AllCarsQueryModel query)
        {
            var queryResult = _carService.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            var carBrands = _carService.AllBrands();

            query.Brands = carBrands;
            query.TotalCars = queryResult.TotalCars;
            query.Cars = queryResult.Cars;

            return View(query);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var myCars = _carService.ByUser(this.User.Id());

            return View(myCars);
        }

        public IActionResult Details(int id, string information)
        {
            var car = _carService.Details(id);

            if (information != car.GetInformation())
            {
                return BadRequest();
            }

            var comments = _commentService.GetCommentsByCarId(id);

            var commentsModel = new CommentsModel
            {
                Comments = comments
            };

            var view = new DetailsModel
            {
                CarDetailModel = car,
                Comments = commentsModel
            };

            return View(view);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!_dealerService.IsDealer(this.User.Id()))
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            return View(new CarFormModel
            {
                Categories = _carService.AllCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CarFormModel car)
        {
            var dealerId = _dealerService.DealerIdByUser(this.User.Id());

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            if (!_carService.CategoryExists(car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = _carService.AllCategories();

                return View(car);
            }

            var carId = _carService.Create(
                car.Brand,
                car.Model,
                car.Description,
                car.ImageUrl,
                car.Year,
                car.CategoryId,
                dealerId);

            TempData[GlobalMessageKey] = "You car was added and is awaiting for approval!";

            return RedirectToAction(nameof(Details), new { id = carId, information = car.GetInformation() });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.Id();

            if (!_dealerService.IsDealer(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            var car = _carService.Details(id);

            if (car.UserId != userId && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var carForm = _mapper.Map<CarFormModel>(car);

            carForm.Categories = _carService.AllCategories();

            return View(carForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, CarFormModel car)
        {
            var dealerId = _dealerService.DealerIdByUser(this.User.Id());

            if (dealerId == 0 && !User.IsAdmin())
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            if (!_carService.CategoryExists(car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = _carService.AllCategories();

                return View(car);
            }

            if (!_carService.IsByDealer(id, dealerId) && !User.IsAdmin())
            {
                return BadRequest();
            }

            var edited = _carService.Edit(
                id,
                car.Brand,
                car.Model,
                car.Description,
                car.ImageUrl,
                car.Year,
                car.CategoryId,
                this.User.IsAdmin());

            if (!edited)
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You car was edited{(this.User.IsAdmin() ? string.Empty : " and is awaiting for approval")}!";

            return RedirectToAction(nameof(Details), new { id, information = car.GetInformation() });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var dealerId = _dealerService.DealerIdByUser(this.User.Id());

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            _carService.DeleteCar(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
