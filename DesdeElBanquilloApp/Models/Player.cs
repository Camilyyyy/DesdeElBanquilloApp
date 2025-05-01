using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DesdeElBanquilloApp.Models
{
    public class Player
    {
        //PK
        [Key]
        public int IdPlayer { get; set; }

        [Required]
        [DisplayName("Numero de Jugador")]
        public int PlayerNumber { get; set; }

        [Required]
        [MaxLength(80)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName(" Activo")]
        public bool isActive { get; set; }

        [Required]
        [DisplayName("Edad")]
        public int Age { get; set; }

        [ForeignKey("Country")]
        public int idCountry { get; set; }
        public Country? Country { get; set; }

        [ForeignKey("Team")]
        public int idTeam { get; set; }
        public FTeam? Team { get; set; }

        [ForeignKey("Position")]
        public int idPosition { get; set; }
        public Position? Position { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();

    }
}
