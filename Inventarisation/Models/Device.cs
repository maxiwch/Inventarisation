using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventarisation.Models
{
    public partial class Device
    {
        public Device()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        [Display(Name = "Модель")]
        public string Name { get; set; } = null!;
        [Display(Name = "Цена")]
        public int Price { get; set; }
        public int TypeOfDeviceId { get; set; }
        public int ProducerId { get; set; }
        [Display(Name = "Дата покупки")]
        public DateTime DataOfPurchace { get; set; }
        public int StatusId { get; set; }
        [Display(Name = "Комментарии")]
        public string? Comments { get; set; }
        [Display(Name = "Серийный номер")]
        public string? SerialNumber { get; set; }

        [Display(Name = "Производитель")]
        public virtual Producer? Producer { get; set; }
        [Display(Name = "Статус")]
        public virtual Status? Status { get; set; }
        [Display(Name = "Тип устройства")]
        public virtual TypesOfDevice? TypeOfDevice { get; set; } 
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
