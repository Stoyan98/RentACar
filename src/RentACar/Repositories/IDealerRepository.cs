using RentACar.Data.Models;

namespace RentACar.Repositories
{
    public interface IDealerRepository
    {
        void Add(Dealer dealer);

        bool IsDealer(string userId);

        int DealerIdByUser(string userId);
    }
}
