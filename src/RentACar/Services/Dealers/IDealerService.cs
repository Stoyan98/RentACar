using RentACar.Data.Models;

namespace RentACar.Services.Dealers
{
    public interface IDealerService
    {
        void AddDealer(Dealer dealer);

        bool IsDealer(string userId);

        int DealerIdByUser(string userId);
    }
}
