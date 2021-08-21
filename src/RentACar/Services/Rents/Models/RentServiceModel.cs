using System;

namespace RentACar.Services.Rents.Models
{
    public class RentServiceModel : IRentModel
    {
        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public string PhoneNumber { get; init; }
    }
}
