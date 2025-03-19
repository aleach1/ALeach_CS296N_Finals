using CharacterCreator.Models;
using System.Runtime.Intrinsics.X86;
using System;
using CharacterCreator.Data;
using Microsoft.AspNetCore.Identity;

namespace CelesteMountain.Data
{
    public class SeedData

    {
        public static void Seed(CharacterCreatorContext context, IServiceProvider provider)
        {
            if (!context.Characters.Any())  // this is to prevent adding duplicate data
            {

                // Queue up user objects to be saved to the DB
                var userManager = provider
                    .GetRequiredService<UserManager<AppUser>>();

                const string SECRET_PASSWORD = "Secret!123";
                AppUser account1 = new AppUser { UserName = "Tolkien" };
                var result = userManager.CreateAsync(account1, SECRET_PASSWORD);
                AppUser account2 = new AppUser { UserName = "Cuttlefish" };
                result = userManager.CreateAsync(account2, SECRET_PASSWORD);
                AppUser account3 = new AppUser { UserName = "NoviceWriter" };
                result = userManager.CreateAsync(account3, SECRET_PASSWORD);
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
                    Poster = account1
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
                    Poster = account2
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
                    Poster = account3
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
                    Poster = account3
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
                    Poster = account1
                };
                context.Characters.Add(character);  // queues up a character to be added to the DB

                context.SaveChanges(); // stores all the characters in the DB
                
                Comment comment = new Comment
                {
                    CommentText = "This character seems kind of like a dragon.",
                    DatePosted = DateTime.Parse("03/17/2025"),
                    Commenter = account2,
                    CharacterId = 1
                };
                context.Comments.Add(comment); // queues up a comment to add to db

                comment = new Comment
                {
                    CommentText = "This guy seems very cool. I would enjoy reading a story about him.",
                    DatePosted = DateTime.Parse("03/17/2025"),
                    Commenter = account2,
                    CharacterId = 3
                };
                context.Comments.Add(comment);

                comment = new Comment
                {
                    CommentText = "This guy seems awful. Can't wait to see cool guy triumph over him.",
                    DatePosted = DateTime.Parse("03/17/2025"),
                    Commenter = account1,
                    CharacterId = 4
                };
                context.Comments.Add(comment);

                context.SaveChanges(); // stores all the comments in the DB
            }

            if (!context.Posts.Any())
            {
                // Queue up user objects to be saved to the DB
                var userManager = provider
                    .GetRequiredService<UserManager<AppUser>>();

                const string SECRET_PASSWORD = "Secret!123";
                AppUser account1 = new AppUser { UserName = "Person1" };
                var result = userManager.CreateAsync(account1, SECRET_PASSWORD);
                AppUser account2 = new AppUser { UserName = "Person2" };
                result = userManager.CreateAsync(account2, SECRET_PASSWORD);
                AppUser account3 = new AppUser { UserName = "Person3" };
                result = userManager.CreateAsync(account3, SECRET_PASSWORD);
                context.SaveChanges();  // Saving adds User to User objects

                Post post = new Post
                {
                    Title = "How should I make non-humanoid sapient creatures?",
                    Text = "I want to make non-humanoid sapient characters but I'm worried that I'll just write a human and will leave it's non-human traits out of it's backstory",
                    DatePosted = DateTime.Parse("03/16/2025"),
                    Poster = account3
                };
                context.Posts.Add(post); //Queuing a post to add to db


                post = new Post
                {
                    Title = "First time making a post here",
                    Text = "I am making a post for the very first time. Everybody congratulate me.",
                    DatePosted = DateTime.Parse("03/16/2025"),
                    Poster = account1
                };
                context.Posts.Add(post); //Queuing a post to add to db


                context.SaveChanges(); //Saves posts to database

                Comment comment = new Comment
                {
                    CommentText =  "I feel like most non-humanoid sapient characters are that anyways so it's fine if you do it.",
                    DatePosted =  DateTime.Parse("03/17/2025"),
                    Commenter = account2,
                    PostId = 1
                };
                context.Comments.Add(comment);//Queuing a comment to add to db

                comment = new Comment
                {
                    CommentText = "Congrats on making a post!",
                    DatePosted = DateTime.Parse("03/17/2025"),
                    Commenter = account2,
                    PostId = 2
                };
                context.Comments.Add(comment); //Queuing a comment to add to db

                comment = new Comment
                {
                    CommentText = "Wow! first post. Congrats.",
                    DatePosted = DateTime.Parse("03/17/2025"),
                    Commenter = account3,
                    PostId = 2
                };
                context.Comments.Add(comment); //Queuing a comment to add to db

                context.SaveChanges(); //Saves comments to database
            }

        }

    }

}

