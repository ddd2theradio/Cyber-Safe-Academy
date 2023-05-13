using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }                                                 // Represents the identifier of the training module.
        public string Name { get; set; }                                            // Represents the name of the training module.

        public ICollection<TrainingModuleMaterial> Materials { get; set; }          // Represents a collection of training module materials associated with the training module.
    }
   

}
