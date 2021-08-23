using RentACar.Data;
using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public class CommentRepository : Repository, ICommentRepository
    {
        private readonly RentACarDbContext _context;

        public CommentRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public void Remove(int id)
        {
            var comment = _context.Comments.Where(c => c.Id == id).FirstOrDefault();

            _context.Comments.Remove(comment);

            Save();
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }
    }
}
