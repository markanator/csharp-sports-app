using SportsLib.Models;
using SportsLib.Interfaces;
using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ITeam
    {
        List<Player> TeamPlayers { get; set; }
        string Name { get; set; }
        ISport Sport { get; }
        void AddPlayer(Player _player);
        void RemovePlayer(Player _player);
    }
}