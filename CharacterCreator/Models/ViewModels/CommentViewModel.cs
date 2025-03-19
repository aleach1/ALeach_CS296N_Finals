

namespace CharacterCreator.Models
{
    public class CommentViewModel
    {
        public Character Character { get; set; }
        public Post? Post { get; set; }
        public Comment? Comment { get; set; }
    }
}
