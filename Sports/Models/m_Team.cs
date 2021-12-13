using SportsLib.Interfaces;
using SportsLib.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsMVC.Models
{
    public class m_Team
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SportId { get; set; }
        public m_Sport Sport { get; set; }

        public List<m_Player> TeamPlayers { get; set; }

    }
}
