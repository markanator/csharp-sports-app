using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ISport
    {
        string Description { get; set; }
        string Name { get; set; }
        List<ITeam> SportTeams { get; set; }
        void AddSportTeam(ITeam _team);
        void RemoveSportTeam(ITeam _team);
    }
}