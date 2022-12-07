using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        [Display(Name = "Производитель")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
