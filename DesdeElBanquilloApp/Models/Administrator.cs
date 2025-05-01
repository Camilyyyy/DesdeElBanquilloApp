using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesdeElBanquilloApp.Models
{
    public class Administrator
    {
        [Key]
        public int Id_Admin { get; set; }
        [ForeignKey(nameof(Id_Admin))]
        //
        [Required]  // No se puede crear un Admin sin nombre osea no null 
        [MaxLength(80)] // Maximo de caracteres soportados 
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
