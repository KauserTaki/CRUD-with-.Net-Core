using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud_core_m_table_ent.Models
{
    public class Student
    {
        [Key]

        public int ID { get; set; }

        [Required(ErrorMessage ="Required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]

        public string Gender { get; set; }

        [Required(ErrorMessage = "Required")]


        public int Age { get; set; }

        [Required(ErrorMessage = "Required")]

        [Display(Name="Department")]

        public int Department_Name { get; set; }

        [Required(ErrorMessage ="Required")]

        [NotMapped]
        public string Department { get; set; }


    }
}
