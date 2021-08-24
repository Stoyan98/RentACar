using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentACar.Data.Models;
using RentACar.Repositories;
using RentACar.Services.Rents.Models;
using System;
using System.Collections.Generic;

namespace RentACar.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IConfigurationProvider _mapper;

        public RentService(IRentRepository rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper.ConfigurationProvider;
        }

        public IEnumerable<RentServiceModel> GetAll()
        {
            return _rentRepository
                .GetAll()
                .ProjectTo<RentServiceModel>(_mapper);
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

        public void Remove(int id)
        {
            _rentRepository.Remove(id);
        }
    }
}
