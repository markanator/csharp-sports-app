using SportsLib.US_Sports;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsMVC.Models
{
    public class m_SportsRepo
    {
        public int Id { get; set; }
        [Required]
        public string RepoName { get; set; }
        public List<m_Sport> SportsList { get; set; }
    }
}
