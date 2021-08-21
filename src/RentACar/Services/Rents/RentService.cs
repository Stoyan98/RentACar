using AutoMapper;
using RentACar.Data.Models;
using RentACar.Repositories;
using System;

namespace RentACar.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;

        public RentService(IRentRepository rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }

        public int Create(
            string firstName, 
            string lastName, 
            string phoneNumber, 
            DateTime startDate, 
            DateTime endDate, 
            int carId, 
            string userId)
        {
            var rentData = new Rent
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                StartDate = startDate,
                EndDate = endDate,
                CarId = carId,
                UserId = userId
            };

            _rentRepository.Add(rentData);

            return rentData.Id;
        }
    }
}
