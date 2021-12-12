using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsLib.Models
{
    public abstract class SportsRepo : ISportsRepo
    {
        public List<ISport> SportsList { get; set; }
        public SportsRepo() { }
        public SportsRepo(List<ISport> _sportsList) {
            this.SportsList = _sportsList;
        }
        public void AddSport(ISport _sport)
        {
            this.SportsList.Add(_sport);
        }
        public void RemoveSport(ISport _sport)
        {
            this.SportsList.Remove(_sport);
        }
    }
}
