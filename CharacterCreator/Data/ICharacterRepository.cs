using CharacterCreator.Models;

namespace CharacterCreator.Data
{
    public interface ICharacterRepository
    {
        public Character GetCharById(int id);
        public Post GetPostById(int id);
        public List<Character> GetAllChars();
        public List<Post> GetAllPosts();
        public Task<int> NewCharAsync(Character model);
        public Task<int> NewPostAsync(Post model);
        public Task<int> DeletePostsAsync(AppUser appUser);
        public Task<int> DeleteCharactersAsync(AppUser appUser);
        public Task<int> NewCommentAsync(Comment model);
    }
}
