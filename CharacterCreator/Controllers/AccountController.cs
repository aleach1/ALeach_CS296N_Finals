using CharacterCreator.Data;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CharacterCreator.Controllers
{
    public class AccountController : Controller
    {

        ICharacterRepository _repo;

        public AccountController(ICharacterRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User newUser)
        {

            if (_repo.NewUser(newUser) > 0)
            {
                ViewBag.Success = "text-success";
                ViewBag.Message = "Your account was successfully saved.";
                return View();
            }
            else
            {
                ViewBag.Success = "text-danger";
                ViewBag.Message = "There was an error saving the account. Your username may have been invalid.";
                return View();
            }
        }
    }
}
