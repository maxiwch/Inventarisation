using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        [Display(Name = "Отдел")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
