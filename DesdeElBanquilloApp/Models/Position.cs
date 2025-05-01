using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DesdeElBanquilloApp.Models
{
    public class Position
    {
        [Key]
        public int IdPosition { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre Posicion")]
        public string PositionName { get; set; }
    }
}
