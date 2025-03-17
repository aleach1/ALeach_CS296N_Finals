using CharacterCreator.Data;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CharacterCreator.Controllers
{
    public class PostController : Controller
    {

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        ICharacterRepository _repo;
        public PostController(ILogger<HomeController> logger, ICharacterRepository repo, UserManager<AppUser> usrMngr,
            SignInManager<AppUser> signInMngr)
        {
            _repo = repo;
            userManager = usrMngr;
            signInManager = signInMngr;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllChars();
            return View(posts);
        }

        [Authorize]
        public IActionResult NewPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NewPost(Post newPost)
        {
            // send user to login if not logged in
            if (!signInManager.IsSignedIn(User))
            {
                var returnURL = Request.GetEncodedUrl();
                return RedirectToAction("Login", "Account", returnURL);
            }

            // get appuser for current user
            newPost.Poster = userManager.GetUserAsync(User).Result;
            if (userManager != null)
            {
                newPost.Poster = await userManager.GetUserAsync(User);
            }
            if (ModelState.IsValid)
            {
                if (await _repo.NewPostAsync(newPost) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "There was an error saving the post.";
                    return View();
                }
            }
            else { return View(); }
        }

        [Authorize]
        public IActionResult Comment(int postId)
        {
            CommentViewModel CommentVM = new CommentViewModel { Post = _repo.GetPostById(postId) };
            return View(CommentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel commentVM)
        {
            Comment newComment = commentVM.Comment;
            // send user to login if not logged in
            if (!signInManager.IsSignedIn(User))
            {
                var returnURL = Request.GetEncodedUrl();
                return RedirectToAction("Login", "Account", returnURL);
            }

            // get appuser for current user
            newComment.Commenter = userManager.GetUserAsync(User).Result;
            if (userManager != null)
            {
                newComment.Commenter = await userManager.GetUserAsync(User);
            }
            if (ModelState.IsValid)
            {
                if (await _repo.NewCommentAsync(newComment) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "There was an error saving the comment.";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }
}
