using RentACar.Services.Comments.Models;
using System;
using System.Collections.Generic;

namespace RentACar.Services.Comments
{
    public interface ICommentService
    {
        void Create(
               string commentMessage,
               DateTime commentDate,
               int carId,
               string userId);

        IEnumerable<CommentServiceModel> GetCommentsByCarId(int carId);

        void RemoveComment(int id);
    }
}
