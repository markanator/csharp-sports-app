using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib.Models
{
    public class Player: Person, IPlayer
    {
        public int RosterNumber { get; set; }

        public ISport Sport { get; }

        public Player(string _name, int _rosterNum, ISport _sport ): base(_name)
        {
            this.Name = _name;
            this.Sport = _sport;
            this.RosterNumber = _rosterNum;
        }
        public void UpdateRosterNumber(int _newNum)
        {
            this.RosterNumber = _newNum;
        }

    }
}