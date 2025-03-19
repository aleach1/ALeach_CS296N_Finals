using CharacterCreator.Data;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CharacterCreator.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        ICharacterRepository _repo;
        public HomeController(ILogger<HomeController> logger, ICharacterRepository repo, UserManager<AppUser> usrMngr,
            SignInManager<AppUser> signInMngr)
        {
            _logger = logger;
            _repo = repo;
            userManager = usrMngr;
            signInManager = signInMngr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Characters()
        {
            var chars = _repo.GetAllChars();
            return View(chars);
        }

        [HttpGet]
        public IActionResult Filter(string creator, string sort)
        {
            if (sort == "Name")
            {
                var chars = _repo.GetAllChars()
                    .Where(s => creator == null ||(s.Poster != null && s.Poster.UserName == creator))
                    .OrderBy(s => s.Name)
                    .ToList();
                return View("Characters", chars);
            }
            else if (sort == "Date")
            {
                var chars = _repo.GetAllChars()
                    .Where(s => creator == null || (s.Poster != null && s.Poster.UserName == creator))
                    .OrderBy(s => s.DateCreated)
                    .ToList();
                return View("Characters", chars);
            }
            else if (sort == "Height")
            {
                var chars = _repo.GetAllChars()
                    .Where(s => creator == null || (s.Poster != null && s.Poster.UserName == creator))
                    .OrderBy(s => s.Height)
                    .ToList();
                return View("Characters", chars);
            }
            else
            {
                var chars = _repo.GetAllChars()
                    .Where(s => creator == null || (s.Poster != null && s.Poster.UserName == creator))
                    .ToList();
                return View("Characters", chars);
            }


        }

        [Authorize]
        public IActionResult NewChar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NewChar(Character newChar)
        {

            // send user to login if not logged in
            if (!signInManager.IsSignedIn(User))
            {
                var returnURL = Request.GetEncodedUrl();
                return RedirectToAction("Login", "Account", returnURL);
            }

            // get appuser for current user
            newChar.Poster = userManager.GetUserAsync(User).Result;
            if (userManager != null)
            {
                newChar.Poster = await userManager.GetUserAsync(User);
            }
            if (ModelState.IsValid)
            {
                if (await _repo.NewCharAsync(newChar) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "There was an error saving the character.";
                    return View();
                }
            }
            else {
                ViewBag.ErrorMessage = "The model state was invalid.";
                return View();
            }
        }

        [Authorize]
        public IActionResult Comment(int charId)
        {
            CommentViewModel CommentVM = new CommentViewModel { Character = _repo.GetCharById(charId) };
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
