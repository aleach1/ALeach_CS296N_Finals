using CharacterCreator.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace CharacterCreator.Data
{
    public class CharacterCreatorContext : DbContext
    {

        // constructor just calls the base class constructor

        public CharacterCreatorContext(

           DbContextOptions<CharacterCreatorContext> options) : base(options) { }


        // one DbSet for each domain model class
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

    }
}
