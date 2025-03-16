using CharacterCreator.Data;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CharacterCreator.Controllers
{
    public class QuizController : Controller
    {
        ICharacterRepository _repo;
        public QuizController(ICharacterRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new QuizModel();
            viewModel.Questions.Add(new Question() { CorrectAnswer = "", UserAnswer="", IsCorrect=false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = "", UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = "", UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = "", UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = "", UserAnswer = "", IsCorrect = false });


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(QuizModel submittedViewModel)
        {
            // Create a new ViewModel with the correct questions
            var viewModel = new QuizModel();
            viewModel.Questions.Add(new Question() { CorrectAnswer = _repo.GetAllChars().OrderBy(c => c.Height).Last().Name, UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = _repo.GetAllChars().OrderBy(c => c.Height).First().Name, UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = _repo.GetAllChars().OrderBy(c => c.DateCreated).First().Name, UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question(){ CorrectAnswer = _repo.GetAllChars().OrderBy(c => c.Id).First().Name, UserAnswer = "", IsCorrect = false });
            viewModel.Questions.Add(new Question() { CorrectAnswer = _repo.GetAllChars().OrderBy(c => c.Id).Last().Name, UserAnswer = "", IsCorrect = false });

            // Update the UserAnswerIndex for the original questions with the submitted answers
            for (int i = 0; i < viewModel.Questions.Count; i++)
            {
                viewModel.Questions[i].UserAnswer = submittedViewModel.Questions[i].UserAnswer;
            }


            // Add score and show correct answers
            int score = viewModel.CalculateScore();
            ViewData["Score"] = score;
            ViewData["Checked"] = true;

            return View(viewModel);
        }
    }
}
