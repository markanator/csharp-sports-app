using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib.Models
{
    public abstract class ProSports : ISportsRepo
    {
        public List<ISport> PopularSports { get; set; }
        public string NameOfLeague { get; set; }
        public string Description { get; set; }

        public ProSports(string _leagueName, string _desc)
        {
            this.NameOfLeague = _leagueName;
            this.Description = _desc;
            this.PopularSports = new List<ISport>();
        }

        public void AddSport(ISport _newSport)
        {
            this.PopularSports.Add(_newSport);
        }

        public void RemoveSport(ISport _removeSport)
        {
            this.PopularSports.Remove(_removeSport);
        }
    }
}