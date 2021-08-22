using System;

namespace RentACar.Services.Comments.Models
{
    public class CommentServiceModel : ICommentModel
    {
        public int Id { get; set; }

        public string CommentMessage { get; init; }

        public DateTime CommentDate { get; init; }
    }
}
