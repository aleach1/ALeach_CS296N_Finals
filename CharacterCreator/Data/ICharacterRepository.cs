using CharacterCreator.Models;

namespace CharacterCreator.Data
{
    public interface ICharacterRepository
    {
        public Character GetCharById(int id);
        public List<Character> GetAllChars();
        public List<User> GetAllUsers();
        public int NewChar(Character model);
        public int NewUser(User model);
    }
}
