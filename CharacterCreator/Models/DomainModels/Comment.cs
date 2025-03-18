using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Comment Requires Body Text")]
        [StringLength(500)]
        public String CommentText { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public AppUser? Commenter { get; set; }
        public int? CharacterId { get; set; }  // FK to cause cascade delete
        public int? PostId { get; set; }
    }
}
