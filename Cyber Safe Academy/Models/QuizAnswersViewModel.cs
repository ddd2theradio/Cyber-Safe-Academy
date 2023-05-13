using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Models
{
    public class QuizAnswersViewModel
    {
        public int QuizID { get; set; }                    // Identifier of the quiz

        public string Answer_0 { get; set; }               // Answer for the first question 
        public string Answer_1 { get; set; }               // Answer for the second question
        public string Answer_2 { get; set; }               // Answer for the third question

        public bool Answer_0correct { get; set; }          // Indicates whether the answer to the first question is correct 
        public bool Answer_1correct { get; set; }          // Indicates whether the answer to the second question is correct
        public bool Answer_2correct { get; set; }          // Indicates whether the answer to the third question is correct

        public bool AnswersSubmitted { get; set; }         // Indicates whether the answers have been submitted

        public Quiz Quiz { get; set; }                     // Reference to the Quiz object associated with the answers
    }
}
