using CharacterCreator.Models;
using System.Runtime.Intrinsics.X86;
using System;
using CharacterCreator.Data;

namespace CelesteMountain.Data
{
    public class SeedData

    {
        public static void Seed(CharacterCreatorContext context)
        {
            if (!context.Characters.Any())  // this is to prevent adding duplicate data
            {
                // Create User objects
                User account1 = new User { Username = "Tolkien", Password = "Password1" };
                User account2 = new User { Username = "Cuttlefish", Password = "Password1" };
                User account3 = new User { Username = "NoviceWriter", Password = "Password1" };

                // Queue up user objects to be saved to the DB
                context.Users.Add(account1);
                context.Users.Add(account2);
                context.Users.Add(account3);
                context.SaveChanges();  // Saving adds User to User objects

                Character character = new Character
                {
                    Name = "Smaug",
                    Backstory = "Smaug, a fearsome red dragon from J.R.R Tolkien's \"The Hobbit,\" is a powerful, greedy " +
                    "creature who conquered the Dwarf kingdom of Erebor, driving out its inhabitants and claiming their vast " +
                    "treasure hoard as his own",
                    Motivation = "Loves gold",
                    MoralAlignment = "Neutral Evil",
                    Height = 18300,
                    Weight = 63000,
                    PhysicalDescription = "He is a dragon. Looks like a dragon.",
                    DateCreated = DateTime.Parse("09/21/1937"),
                    Account = account1
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                character = new Character
                {
                    Name = "Klein Moretti",
                    Backstory = "Waking up in the body of Klein Moretti, Zhou Mingrui finds that he is in another world. This" +
                    " new world seems to be in the middle of the industrial revolution, but he soon realizes that there is " +
                    "magic behind the scenes.",
                    Motivation = "Returning to his home world",
                    MoralAlignment = "Neutral Good",
                    Height = 172,
                    Weight = 70,
                    PhysicalDescription = "His original body has black hair, brown eyes, an average-looking face, a deep " +
                    "outline, and is thinly built. Klein also has a distinct scholarly air to him. His refined aura is " +
                    "further reinforced by the valuable suits he dressed with and the canes he held on all occasions.",
                    DateCreated = DateTime.Parse("04/01/2018"),
                    Account = account2
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                character = new Character
                {
                    Name = "Cool Guy",
                    Backstory = "Cool Guy is a superhero who got cool powers because he's just too cool.",
                    Motivation = "None needed",
                    MoralAlignment = "Lawful Good",
                    Height = 195,
                    Weight = 90,
                    PhysicalDescription = "He just looks too cool.",
                    DateCreated = DateTime.Parse("12/06/2024"),
                    Account = account3
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                character = new Character
                {
                    Name = "Evil Guy",
                    Backstory = "Evil Guy is a supervillain who got evil powers because he's just too mean.",
                    Motivation = "Wants to ruin Cool Guy's cool vibe.",
                    MoralAlignment = "Lawful Evil",
                    Height = 245,
                    Weight = 130,
                    PhysicalDescription = "He just looks too evil.",
                    DateCreated = DateTime.Parse("12/06/2024"),
                    Account = account3
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                character = new Character
                {
                    Name = "Killua Zoldyck",
                    Backstory = "The son of a famous assassin family, Killua finds friendship for the first time and must " +
                    "navigate his emotions and maintain his friendship.",
                    Motivation = "Wants to travel with and protect his sister, Alluka.",
                    MoralAlignment = "True Neutral",
                    Height = 158,
                    Weight = 45,
                    PhysicalDescription = "Killua has spiky silver hair, very pale skin, and blue eyes.",
                    DateCreated = DateTime.Parse("04/06/1998"),
                    Account = null
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                context.SaveChanges(); // stores all the reviews in the DB

            }

        }

    }

}

