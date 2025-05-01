using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesdeElBanquilloApp.Models
{
    public class FTeam
    {
        [Key]
        public int IdFTeam { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nombre Equipo Futbol")]
        public string Name { get; set; }

        //list
        public ICollection<Player> PlayersFteam { get; set; }
        public ICollection<Competition> CompetitionFteam { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }

    }
}
