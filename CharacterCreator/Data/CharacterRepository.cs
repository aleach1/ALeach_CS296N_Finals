using CharacterCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        private CharacterCreatorContext _context;

        public CharacterRepository(CharacterCreatorContext appDbContext)
        {
            _context = appDbContext;
        }

        //return all Characters from repository
        public List<Character> GetAllChars()
        {
            var chars = _context.Characters
                .Include(character => character.Poster)
                .Include(character => character.Comments)
                .ThenInclude(comment => comment.Commenter)
                .ToList<Character>();
            return chars;
        }


        //return a character with a specific id
        public Character GetCharById(int id)
        {
            var chars = _context.Characters
              .Where(chars => chars.CharacterId == id)
                .Include(character => character.Poster)
                .Include(character => character.Comments)
                .ThenInclude(comment => comment.Commenter)
              .SingleOrDefault();
            return chars;
        }

        //return a post with a specific id
        public Post GetPostById(int id)
        {
            var posts = _context.Posts
              .Where(x => x.PostId == id)
                .Include(character => character.Poster)
                .Include(character => character.Comments)
                .ThenInclude(comment => comment.Commenter)
              .SingleOrDefault();
            return posts;
        }


        //adds a character to the database and returns a positive value if succussful. Validates user account.
        public async Task<int> NewCharAsync(Character model)
        {
            model.DateCreated = DateTime.Now;
            _context.Characters.Add(model);
            Task<int> task  = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }

        //adds a Post to the database and returns a positive value if succussful. Validates user account.
        public async Task<int> NewPostAsync(Post model)
        {
            model.DatePosted = DateTime.Now;
            _context.Posts.Add(model);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }

        //Deletes all Posts from a user
        public async Task<int> DeletePostsAsync(AppUser appUser)
        {
            var story = _context.Posts
              .Where(story => story.Poster == appUser)
              .Include(story => story.Poster)
              .ToList();
            _context.Posts.RemoveRange(story);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }

        //Deletes all characters from a user
        public async Task<int> DeleteCharactersAsync(AppUser appUser)
        {
            var story = _context.Characters
              .Where(story => story.Poster == appUser)
              .Include(story => story.Poster)
              .ToList();
            _context.Characters.RemoveRange(story);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }

        //Adds A comment to the database
        public async Task<int> NewCommentAsync(Comment model)
        {
            model.DatePosted = DateTime.Now;
            _context.Comments.Add(model);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }
    }
}
