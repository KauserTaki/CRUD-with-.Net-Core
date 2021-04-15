using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_core_m_table_ent.Models
{
    public class Departments
    {
        [Key]

        public int ID { get; set; }

        public string DepartmentName { get; set; }
    }
}
