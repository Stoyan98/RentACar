using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Data.Models
{
    using static DataConstants.Comment;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string CommentMessage { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
