using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text.RegularExpressions;
namespace DesdeElBanquilloApp.Models
{
    public class Competition
    {

        [Key]
        public int idCompetition { get; set; }

        [Required]
        [MaxLength(80)]
        [DisplayName("Nombre Competicion")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Fecha Inicio")]

        public DateOnly CompetitionStartDate { get; set; }

        [Required]
        [DisplayName("Fecha Finalizacion")]

        public DateOnly CompetitionEndDate { get; set; }

        //FK
        [ForeignKey("Position")]
        public int idFederation { get; set; }
        public Federation? Federation { get; set; }

        //List
        public ICollection<Match> CompetitionMatches { get; set; }

    }
}
