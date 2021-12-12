using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ISportsRepo
    {
        string NameOfLeague { get; set; }
        string Description { get; set; }
        List<ISport> PopularSports { get; set; }
        void AddSport(ISport _newSport);
        void RemoveSport(ISport _removeSport);
    }
}