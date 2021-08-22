using RentACar.Services.Comments.Models;
using System.Collections.Generic;

namespace RentACar.Models.Comments
{
    public class CommentsModel
    {
        public IEnumerable<CommentServiceModel> Comments { get; set; }

        public CommentFormModel CommentFormModel { get; set; }
    }
}
