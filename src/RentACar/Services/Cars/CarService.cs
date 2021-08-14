using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Models;
using RentACar.Repositories;
using RentACar.Services.Cars.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICaregoryRepository _categoryRepository;
        private readonly IConfigurationProvider _mapper;

        public CarService(ICarRepository carRepository, ICaregoryRepository categoryRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper.ConfigurationProvider;
        }

        public CarQueryServiceModel All(
            string brand = null,
            string searchTerm = null,
            CarSorting sorting = CarSorting.DateCreated,
            int currentPage = 1,
            int carsPerPage = int.MaxValue,
            bool publicOnly = true)
        {
            var carsQuery = _carRepository.GetAll()
                .Where(c => !publicOnly || c.IsPublic);

            if (!string.IsNullOrWhiteSpace(brand))
            {
                carsQuery = carsQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            carsQuery = sorting switch
            {
                CarSorting.Year => carsQuery.OrderByDescending(c => c.Year),
                CarSorting.BrandAndModel => carsQuery.OrderBy(c => c.Brand).ThenBy(c => c.Model),
                CarSorting.DateCreated or _ => carsQuery.OrderByDescending(c => c.Id)
            };

            var totalCars = carsQuery.Count();

            var cars = GetCars(carsQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage));

            return new CarQueryServiceModel
            {
                TotalCars = totalCars,
                CurrentPage = currentPage,
                CarsPerPage = carsPerPage,
                Cars = cars
            };
        }

        public IEnumerable<LatestCarServiceModel> Latest()
        {
            return _carRepository
                 .GetAll()
                 .Where(c => c.IsPublic)
                 .OrderByDescending(c => c.Id)
                 .ProjectTo<LatestCarServiceModel>(_mapper)
                 .Take(3)
                 .ToList();
        }

        public CarDetailsServiceModel Details(int id)
        {
            return _carRepository
                   .GetAll()
                   .Where(c => c.Id == id)
                   .ProjectTo<CarDetailsServiceModel>(_mapper)
                   .FirstOrDefault();
        }

        public int Create(string brand, string model, string description, string imageUrl, int year, int categoryId, int dealerId)
        {
            var carData = new Car
            {
                Brand = brand,
                Model = model,
                Description = description,
                ImageUrl = imageUrl,
                Year = year,
                CategoryId = categoryId,
                DealerId = dealerId,
                IsPublic = false
            };

            _carRepository.Add(carData);

            return carData.Id;
        }

        public bool Edit(
            int id,
            string brand,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            bool isPublic)
        {
            var carData = _carRepository.FindById(id);

            if (carData == null)
            {
                return false;
            }

            carData.Brand = brand;
            carData.Model = model;
            carData.Description = description;
            carData.ImageUrl = imageUrl;
            carData.Year = year;
            carData.CategoryId = categoryId;
            carData.IsPublic = isPublic;

            _carRepository.Save();

            return true;
        }

        public IEnumerable<CarServiceModel> ByUser(string userId)
        {
            return GetCars(_carRepository
                  .GetAll()
                  .Where(c => c.Dealer.UserId == userId));
        }

        public bool IsByDealer(int carId, int dealerId)
        {
            return _carRepository
                .GetAll()
                .Any(c => c.Id == carId && c.DealerId == dealerId);
        }

        public void ChangeVisility(int carId)
        {
            var car = _carRepository.FindById(carId);

            car.IsPublic = !car.IsPublic;

            _carRepository.Save();
        }

        public IEnumerable<string> AllBrands()
        {
            return _carRepository
                  .GetAll()
                  .Select(c => c.Brand)
                  .Distinct()
                  .OrderBy(br => br)
                  .ToList();
        }

        public IEnumerable<CarCategoryServiceModel> AllCategories()
        {
            return _categoryRepository.GetAllCategories().ProjectTo<CarCategoryServiceModel>(_mapper).ToList();
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryRepository.CategoryExists(categoryId);
        }

        private IEnumerable<CarServiceModel> GetCars(IQueryable<Car> carQuery)
        {
            return carQuery
                  .ProjectTo<CarServiceModel>(_mapper)
                  .ToList();
        }
    }
}
