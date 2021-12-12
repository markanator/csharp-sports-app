using SportsLib.Interfaces;
using SportsLib.Models;
using System.ComponentModel.DataAnnotations;

namespace SportsMVC.Models
{
    public class m_Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Roster { get; set; }

        public int SportId { get; set; }
        public m_Sport Sport { get; set; }

        public int TeamId { get; set; }
        public m_Team Team { get; set; }
    }
}
