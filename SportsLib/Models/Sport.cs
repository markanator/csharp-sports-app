﻿using SportsLib.Interfaces;
using System;
using System.Collections.Generic;

namespace SportsLib.Models
{
    public abstract class Sport : ISport
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
    }
}