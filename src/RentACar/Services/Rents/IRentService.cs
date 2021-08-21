using System;

namespace RentACar.Services.Rents
{
    public interface IRentService
    {
        int Create(
            string firstName, 
            string lastName, 
            string phoneNumber, 
            DateTime startDate, 
            DateTime endDate, 
            int carId, 
            string userId);
    }
}
