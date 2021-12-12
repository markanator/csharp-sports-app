using SportsLib.US_Sports;
using System.Collections.Generic;

namespace SportsMVC.Models
{
    public class m_SportsRepo
    {
        public int Id { get; set; }
        public List<m_Sport> SportsList { get; set; }
    }
}
