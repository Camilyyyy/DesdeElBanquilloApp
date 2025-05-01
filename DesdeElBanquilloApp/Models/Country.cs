using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DesdeElBanquilloApp.Models
{
    public class Country
    {
        [Key]
        public int idCountry { get; set; }

        [Required]
        [MaxLength(80)]
        [DisplayName("Nombre Pais")]
        public string Name { get; set; }

        //FK
        [ForeignKey("Federation")]
        public int idFederation { get; set; }
        public Federation? Federation { get; set; }

        //Lists

        public required List<FTeam> GetFTeamsCountry;
    }
}
