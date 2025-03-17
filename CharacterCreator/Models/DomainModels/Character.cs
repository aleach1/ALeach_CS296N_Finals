using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterCreator.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string Backstory { get; set; }

        public string? Motivation { get; set; }

        public string? MoralAlignment { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string? PhysicalDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public AppUser Poster { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
