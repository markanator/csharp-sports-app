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
        List<ITeam> fakeTeamMembers;
        Player member1;
        Player member2;

        public TeamTests()
        {
            fakeTeamMembers = new List<ITeam>();
            member1 = new Player("Mark", 16);
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns(sportsName);
            mockSport.Setup(s => s.Description).Returns(sportsDesc);
            mockSport.Setup(s => s.SportTeams).Returns(fakeTeamMembers);
            myTeam = new Team(teamName, mockSport.Object);
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
    }
}
