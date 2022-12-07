using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        [Display(Name ="ФИО")]
        public string Name { get; set; } = null!;
        [Display(Name = "Дата начала работы")]
        public DateTime StartWorkingDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

        [Display(Name = "Отдел")]
        public virtual Department? Department { get; set; } /*= null!;*/

        [Display(Name = "Должность")]
        public virtual Position? Position { get; set; } /*= null!;*/
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
