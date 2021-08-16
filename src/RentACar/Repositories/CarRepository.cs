using RentACar.Data;
using RentACar.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public class CarRepository : Repository, ICarRepository
    {
        private readonly RentACarDbContext _context;

        public CarRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
            _context.Add(car);
            Save();
        }

        public IQueryable<Car> GetAll()
        {
            return _context.Cars;
        }

        public Car FindById(int carId)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == carId);
        }

        public void DeleteCar(int carId)
        {
            var car = FindById(carId);

            _context.Cars.Remove(car);

            Save();
        }
    }
}
