using System.ComponentModel.DataAnnotations;

namespace DesdeElBanquilloApp.Models
{
    public class MatchPlayer
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        // Relaciones de navegación
        public Match Match { get; set; }
        public Player Player { get; set; }

       
        
        [Required]
        public int PositionId { get; set; }
        public Position? Position { get; set; }

        [Range(0, 120)]
        public int MinutesPlayed { get; set; }

        public bool IsStarter { get; set; }
    }
}
