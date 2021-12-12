using SportsLib.Models;
using SportsLib.Interfaces;
using System.Collections.Generic;

namespace SportsLib.Interfaces
{
    public interface ITeam
    {
        List<IPlayer> TeamPlayers { get; set; }
        string Name { get; set; }
        ISport Sport { get; }
        void AddPlayer(IPlayer _player);
        void RemovePlayer(IPlayer _player);
    }
}