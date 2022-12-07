using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Status
    {
        public Status()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }

        [Display(Name = "Статус")]

        [MaxLength(50, ErrorMessage = "Не правильно длинна больше 50")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
