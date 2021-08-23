using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);

        IQueryable<Comment> GetAll();

        void Remove(int id);
    }
}
