using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsLib.Interfaces;
using SportsLib.Models;
using Moq;
using System.Collections.Generic;

namespace SportsLibTests
{
    [TestClass]
    public class TeamTests
    {
        Team myTeam;
        string teamName = "TEAM NAME";
        string sportsName = "Mock Sport Name";
        string sportsDesc = "Mock Sport Description";
        Player member1 = new Player("Mark", 16);

        public TeamTests()
        {
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns(sportsName);
            mockSport.Setup(s => s.Description).Returns(sportsDesc);
            myTeam = new Team(mockSport.Object, teamName);
            myTeam.TeamPlayers.Add(member1);
        }

        [TestMethod]
        public void GetsTeamName()
        {
            Assert.AreEqual(teamName, myTeam.Name);
        }
        [TestMethod]
        public void GetsTeamSport()
        {
            Assert.AreEqual(sportsName, myTeam.Sport.Name);
            Assert.AreEqual(sportsDesc, myTeam.Sport.Description);
        }
        [TestMethod]
        public void GetsTeamPlayers()
        {
            Assert.AreEqual(1, myTeam.TeamPlayers.Count);
            Assert.AreEqual(member1.Name, ((Player)myTeam.TeamPlayers[0]).Name);
            Assert.AreEqual(member1.RosterNumber, myTeam.TeamPlayers[0].RosterNumber);
        }
    }
}
