using SportsLib.Interfaces;
using SportsLib.Models;
using SportsLib.US_Sports;
using System.Collections.Generic;

namespace SportsMVC.Models
{
    public class USSportsRepo : US_SportsRepo
    {
        public static Sport Hockey;
        public static Sport Soccer;
        public static Team BlackHawks;
        public static Team ChicagoFireFC;
        public static Player JonathanT;
        public static Player FranciscoC;
        public static List<ISport> _sports;

        public USSportsRepo()
        {
            //// sport setup
            Hockey ??= new Sport("Hockey", "Its Soccer on ice.");
            Soccer ??= new Sport("Soccer", "Its Foosball in real life.");
            // teams initial setup
            BlackHawks      ??= new Team(Hockey, "Chicago BlackHawks");
            ChicagoFireFC   ??= new Team(Soccer, "Chicago Fire FC");
            // team roster setup
            JonathanT = new Player("Jonathan T.", 19, Hockey);
            FranciscoC = new Player("Francisco C.", 1, Soccer);
            // team rosters setup
            BlackHawks.AddPlayer(JonathanT);
            BlackHawks.AddPlayer(JonathanT);
            ChicagoFireFC.AddPlayer(FranciscoC);
            ChicagoFireFC.AddPlayer(FranciscoC);
            // sport teams setup
            Hockey.AddSportTeam(BlackHawks);
            Soccer.AddSportTeam(ChicagoFireFC);
            // US sports repo setup
            base.SportsList = _sports = new List<ISport>() { Hockey, Soccer };
        }
    }
}
