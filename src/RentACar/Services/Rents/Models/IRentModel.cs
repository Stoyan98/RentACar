using System;

namespace RentACar.Services.Rents.Models
{
    public interface IRentModel
    {
        string FirstName { get; }

        string LastName { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        string PhoneNumber { get; }
    }
}
