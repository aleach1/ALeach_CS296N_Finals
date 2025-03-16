namespace CharacterCreator.Models
{
    public class QuizModel
    {
        public List<Question> Questions { get; set; } = new List<Question>();

        public int CalculateScore()
        {
            int score = 0;
            foreach (var question in Questions)
            {
                    // Determine if the user's answer is correct.
                    question.IsCorrect = question.UserAnswer == question.CorrectAnswer;
                    if (question.IsCorrect)
                    {
                        score++;
                    }
                
            }
            return score;
        }
    }

    public class Question
    {

        public string CorrectAnswer { get; set; } = string.Empty;
        public string UserAnswer { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
    }
}
