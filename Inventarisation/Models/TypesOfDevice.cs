using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class TypesOfDevice
    {
        public TypesOfDevice()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }

        [Display(Name = "Тип устройства")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
