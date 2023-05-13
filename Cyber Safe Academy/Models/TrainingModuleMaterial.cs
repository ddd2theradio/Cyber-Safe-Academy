using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Models
{
  
        public class TrainingModuleMaterial
        {
            public int Id { get; set; }                                  // Represents the unique identifier of the training module material.
        public int TrainingModuleId { get; set; }                        // Represents the foreign key to the associated training module.
        public string Material { get; set; }                             // Represents the material content.

        public TrainingModule TrainingModule { get; set; }               // Represents the associated training module entity.
    }

    }

