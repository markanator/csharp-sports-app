using SportsLib.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsMVC.Models
{
    public class m_Sport
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public List<m_Team> SportTeams { get; set; }

        public int RepoId { get; set; }
        public m_SportsRepo Repo { get; set; }
    }
}
