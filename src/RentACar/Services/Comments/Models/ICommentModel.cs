using System;

namespace RentACar.Services.Comments.Models
{
    public interface ICommentModel
    {
        string CommentMessage { get; }

        DateTime CommentDate { get; }
    }
}
