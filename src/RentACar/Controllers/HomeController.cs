using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RentACar.Models;
using RentACar.Services.Cars;
using RentACar.Services.Cars.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RentACar.Controllers
{
    using static WebConstants.Cache;

    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMemoryCache _cache;

        public HomeController(ICarService carService, IMemoryCache cache)
        {
            _carService = carService;
            _cache = cache;
        }

        public IActionResult Index()
        {
            var latestCars = _cache.Get<List<LatestCarServiceModel>>(LatestCarsCacheKey);

            if (latestCars == null)
            {
                latestCars = _carService
                   .Latest()
                   .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                _cache.Set(LatestCarsCacheKey, latestCars, cacheOptions);
            }

            return View(latestCars);
        }

        public IActionResult Error() => View();
    }
}
