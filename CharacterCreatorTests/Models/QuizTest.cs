using CharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorTests.Models
{
    public class QuizTest
    {
        [Fact]
        public void WrongAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizModel
            {
                Questions = new List<Question>
                {
                    new Question { CorrectAnswer = "Good Answer", UserAnswer = "Bad Answer" }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.False(viewModel.Questions[0].IsCorrect);
        }

        [Fact]
        public void RightAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizModel
            {
                Questions = new List<Question>
                {
                    new Question { CorrectAnswer = "Good Answer", UserAnswer = "Good Answer" }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.True(viewModel.Questions[0].IsCorrect);
        }
    }
}
