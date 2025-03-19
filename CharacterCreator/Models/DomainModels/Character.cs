using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterCreator.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        [Required(ErrorMessage = "Character Requires Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Character requires a backstory")]
        [StringLength(500)]
        public string Backstory { get; set; }

        public string? Motivation { get; set; }

        public string? MoralAlignment { get; set; }

        [Required(ErrorMessage = "Character requires a height")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Character requires a weight")]
        public int Weight { get; set; }

        public string? PhysicalDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public AppUser? Poster { get; set; }

        public ICollection<Comment>? Comments { get; set; }

    }
}
