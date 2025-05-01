using System.ComponentModel.DataAnnotations;

namespace DesdeElBanquilloApp.Models
{
    public class MatchPlayer
    {    // Clave primaria única
        [Key]
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Range(0, 120)]
        public int MinutesPlayed { get; set; }

        public bool IsStarter { get; set; }

        // Propiedades de navegación
        public Match Match { get; set; }
        public Player Player { get; set; }
        public Position Position { get; set; }
    }
}
