using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Repositories;
using System.Linq;

namespace RentACar.Services.Dealers
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _repository;

        public DealerService(IDealerRepository repository)
        { 
            _repository = repository;
        }

        public bool IsDealer(string userId)
        {
            return _repository.IsDealer(userId);
        }

        public int DealerIdByUser(string userId)
        {
            return _repository.DealerIdByUser(userId);
        }

        public void AddDealer(Dealer dealer)
        {
            _repository.Add(dealer);
        }
    }
}
