using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesdeElBanquilloApp.Models
{
    public class Federation
    {
        [Key]
        public int idFederation { get; set; }
        [Required]
        [MaxLength(80)]
        [DisplayName("Nombre Federacion")]
        public string Name { get; set; }

        //lists
        public ICollection<Country> CountriesFederation { get; set; }
        public ICollection<Competition> CompetitionsFederation { get; set; }


    }
}
