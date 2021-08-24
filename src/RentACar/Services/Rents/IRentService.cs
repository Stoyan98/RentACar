using RentACar.Services.Rents.Models;
using System;
using System.Collections.Generic;

namespace RentACar.Services.Rents
{
    public interface IRentService
    {
        IEnumerable<RentServiceModel> GetAll();

        int Create(
            string firstName, 
            string lastName, 
            string phoneNumber, 
            DateTime startDate, 
            DateTime endDate, 
            int carId, 
            string userId);

        void Remove(int id);
    }
}
