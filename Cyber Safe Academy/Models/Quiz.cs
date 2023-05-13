using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Models
{
    public class Quiz       //this line declares a class named 'Quiz'
    {
        public int ID  { get; set; }                 // Unique identifier for the quiz
        public string Name { get; set; }             // Name of the quiz
        public int TrainingModuleID { get; set; }    //Identifier of the training module associated with the quiz      

        public ICollection <QuizQuestion>Questions  { get; set; }       // Collection of quiz questions associated with the quiz
    }
}
