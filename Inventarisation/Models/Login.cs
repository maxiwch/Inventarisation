using System.ComponentModel.DataAnnotations.Schema;

namespace Inventarisation.Models
{
    [NotMapped]
    public class Login
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Password { get; set; }

    }
}
