using SportsLib.Interfaces;
using System;
using System.Collections.Generic;

namespace SportsLib.Models
{
    public class Sport : ISport
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public List<ITeam> SportTeams { get; set; }

        public Sport() {
            this.SportTeams = new List<ITeam>();
        }
        public Sport(string _name, string _desc)
        {
            this.Name = _name;
            this.Description = _desc;
            this.SportTeams = new List<ITeam>();
        }
        public Sport(string _name, string _desc, List<ITeam> _team)
        {
            this.Name = _name;
            this.Description = _desc;
            this.SportTeams = new List<ITeam>();
        }

        public void AddSportTeam(ITeam _team)
        {
            this.SportTeams.Add(_team);
        }
        public void RemoveSportTeam(ITeam _team)
        {
            this.SportTeams.Remove(_team);
        }
    }
}
