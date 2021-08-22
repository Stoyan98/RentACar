using System.ComponentModel.DataAnnotations;

namespace RentACar.Models.Comments
{
    using static Data.DataConstants.Comment;

    public class CommentFormModel
    {
        [Required]
        [MaxLength(CommentMaxLength)]
        public string CommentMessage { get; set; }

        [Required]
        public int CarId { get; set; }

    }
}
