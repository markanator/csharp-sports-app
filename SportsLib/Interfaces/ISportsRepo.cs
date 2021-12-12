using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ISportsRepo
    {
        List<ISport> SportsList { get; set; }
        void AddSport(ISport _sport);
        void RemoveSport(ISport _sport);
    }
}