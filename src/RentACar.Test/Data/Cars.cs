using RentACar.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Test.Data
{
    public class Cars
    {
        public static IEnumerable<Car> ThreePublicCars
            => Enumerable.Range(0, 3).Select(i => new Car
            {
                IsPublic = true
            });
    }
}
