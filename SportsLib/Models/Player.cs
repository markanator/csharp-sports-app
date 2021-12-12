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

        public Player(string _name, int _rosterNum): base(_name)
        {
            this.RosterNumber = _rosterNum;
        }
        public void UpdateRosterNumber(int _newNum)
        {
            this.RosterNumber = _newNum;
        }

    }
}