namespace CharacterCreator.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Backstory { get; set; }

        public string? Motivation { get; set; }

        public string? MoralAlignment { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string? PhysicalDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public User? Account { get; set; }

    }
}
