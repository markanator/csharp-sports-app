using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib.Models
{
    public class Team : ITeam
    {
        public List<IPlayer> TeamPlayers { get; set; }
        public string Name { get; set; }
        public ISport Sport { get; set; }

        public Team(ISport _sport) {
            this.Sport = _sport;
            this.TeamPlayers = new List<IPlayer>();
        }
        public Team(ISport _sport, string _name)
        {
            this.Name = _name;
            this.Sport = _sport;
            this.TeamPlayers = new List<IPlayer>();
        }

        public void AddPlayer(IPlayer _player)
        {
            this.TeamPlayers.Add(_player);
        }

        public void RemovePlayer(IPlayer _player)
        {
            this.TeamPlayers.Remove(_player);
        }
    }
}