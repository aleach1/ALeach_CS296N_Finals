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
                .Include(character => character.Account)
                .ToList<Character>();
            return chars;
        }

        //return all Users from repository
        public List<User> GetAllUsers()
        {
            var users = _context.Users
                .ToList<User>();
            return users;
        }

        //return a character with a specific id
        public Character GetCharById(int id)
        {
            var chars = _context.Characters
              .Where(chars => chars.Id == id)
              .SingleOrDefault();
            return chars;
        }

        //adds a character to the database and returns a positive value if succussful. Validates user account.
        public int NewChar(Character model)
        {
            if (_context.Users.Find(model.Account.Username).Password == model.Account.Password)
            {
                model.Account = _context.Users.Find(model.Account.Username);
            }
            else
            {
                model.Account = null;
            }
            model.DateCreated = DateTime.Now;
            _context.Characters.Add(model);
            return _context.SaveChanges();
        }

        //adds a user to the database and returns a positive value if succussful. Validates unique user so db doesn't crash.
        public int NewUser(User model)
        {
            if (_context.Users.Find(model.Username) == null)
            {
                _context.Users.Add(model);
                return _context.SaveChanges();
            }
            else
            {
                return 0;
            }
            
        }
    }
}
