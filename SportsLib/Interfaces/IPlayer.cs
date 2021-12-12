using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsLib.Interfaces
{
    public interface IPlayer
    {
        ISport Sport { get; }
        int RosterNumber { get; set; }
    }
}
