using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib.Models
{
    public class SportsLeague : ISportsLeague
    {
        public ISport LeagueSport { get; set; }
        public string NameOfLeague { get; set; }
        public string Description { get; set; }
        public List<ITeam> SportTeams { get; set; }

        public SportsLeague(ISport _sport, string _leagueName, string _desc)
        {
            this.NameOfLeague = _leagueName;
            this.Description = _desc;
            this.LeagueSport = _sport;
            this.SportTeams = new List<ITeam>();
        }
        public SportsLeague(ISport _sport, string _leagueName, string _desc, List<ITeam> _teams)
        {
            this.NameOfLeague = _leagueName;
            this.Description = _desc;
            this.LeagueSport = _sport;
            this.SportTeams = _teams;
        }
    }
}