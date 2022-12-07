using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Transfer
    {
        public int EmployeeId { get; set; }
        public int DeviceId { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime DateStart { get; set; }
        [Display(Name = "Комментарии при выдаче")]
        public string? CommentsStart { get; set; }
        [Display(Name = "Дата сдачи")]
        public DateTime? DateEnd { get; set; }
        [Display(Name = "Комментарии при сдаче")]
        public string? CommentsEnd { get; set; }
        public int Id { get; set; }

        public virtual Device? Device { get; set; } /*= null!;*/
        public virtual Employee? Employee { get; set; }/* = null!;*/
    }
}
