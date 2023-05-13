namespace Cyber_Safe_Academy.Models
{
    public class QuizQuestion
    {
        public int ID { get; set; }                             // Represents the identifier of the quiz question.


        public int QuizID { get; set; }                         // Represents the identifier of the quiz that this question belongs to.

        public string Question { get; set; }                    // Represents the actual question text of the quiz question.

        public string CorrectAnswer { get; set; }               // Represents the correct answer to the quiz question.

        public string IncorrectAnswer1 { get; set; }            // Represents the first incorrect answer option for the quiz question.
        public string IncorrectAnswer2 { get; set; }            // Represents the second incorrect answer option for the quiz question.
        public string IncorrectAnswer3 { get; set; }            // Represents the third incorrect answer option for the quiz question.

    }
}