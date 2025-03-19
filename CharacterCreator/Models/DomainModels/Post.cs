using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Post Requires Title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Post Requires Body Text")]
        [StringLength(500)]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public AppUser? Poster { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
