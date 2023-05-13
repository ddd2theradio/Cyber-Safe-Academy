using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Models
{
    public class Student
    {
        public int Id { get; set; }             // Represents the identifier of the student.

        public string Name { get; set; }        // Represents the name of the student.
        public string Company { get; set; }     // Represents the company associated with the student.
    }
}