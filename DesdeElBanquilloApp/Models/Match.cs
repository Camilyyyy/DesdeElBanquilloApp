using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesdeElBanquilloApp.Models
{
    public class Match
    {
        [Key]
        public int IdMatch { get; set; }

        [Required]
        [DisplayName("Fecha Partido")]
        public DateTime MatchDate { get; set; }
        [DisplayName("Duracion Partido")]
        public string MatchDuration { get; set; }


        [Required]
        [DisplayName("¿Partido Finalizado?")]
        public bool IsMatch { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        //FK
        [ForeignKey("HomeTeam")]
        public FTeam? HomeTeam { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
       
        [ForeignKey("AwayTeam")]
        public FTeam? AwayTeam { get; set; }
        [Required]
        public int AwayTeamId { get; set; }


     

        //list
    }
}