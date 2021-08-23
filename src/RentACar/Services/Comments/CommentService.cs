using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentACar.Data.Models;
using RentACar.Repositories;
using RentACar.Services.Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IConfigurationProvider _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper.ConfigurationProvider;
        }

        public void Create(string commentMessage, DateTime commentDate, int carId, string userId)
        {
            var comment = new Comment
            {
                CommentMessage = commentMessage,
                CommentDate = commentDate,
                CarId = carId,
                UserId = userId
            };

            _commentRepository.Add(comment);
        }

        public IEnumerable<CommentServiceModel> GetCommentsByCarId(int carId)
        {
            return _commentRepository
                .GetAll()
                .Where(c => c.CarId == carId)
                .OrderByDescending(x => x.CommentDate)
                .ProjectTo<CommentServiceModel>(_mapper)
                .ToList();
        }

        public void RemoveComment(int id)
        {
            _commentRepository.Remove(id);
        }
    }
}
