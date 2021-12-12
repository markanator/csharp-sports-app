using SportsLib.Models;
using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ISportsLeague
    {
        string NameOfLeague { get; set; }
        string Description { get; set; }
        public ISport LeagueSport { get; set; }
        List<ITeam> SportTeams { get; set; }
    }
}