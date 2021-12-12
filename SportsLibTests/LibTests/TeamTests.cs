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
        Player member1;
        string member1Name = "Mark";
        int member1RosterNum = 16;
        ISport mySport;

        public TeamTests()
        {
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns(sportsName);
            mockSport.Setup(s => s.Description).Returns(sportsDesc);
            mySport = mockSport.Object;

            myTeam = new Team(mySport, teamName);
            member1 = new Player(member1Name, member1RosterNum, mySport);

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
        [TestMethod]
        public void AddsTeamMembers()
        {
            // arrange
            Player p1 = new Player("Adrian", 7, mySport);
            Player p2 = new Player("Luca", 22, mySport);
            int teamMembersCountOG = myTeam.TeamPlayers.Count, teamMemberCountAfter1, teamMemberCountAfter2;
            // act
            myTeam.TeamPlayers.Add(p1);
            teamMemberCountAfter1 = myTeam.TeamPlayers.Count;
            myTeam.TeamPlayers.Add(p2);
            teamMemberCountAfter2 = myTeam.TeamPlayers.Count;
            // assert
            Assert.AreEqual(1, teamMembersCountOG);
            Assert.AreEqual(member1.Name, ((Player)myTeam.TeamPlayers[0]).Name);
            Assert.AreEqual(2, teamMemberCountAfter1);
            Assert.AreEqual(p1.Name, ((Player)myTeam.TeamPlayers[1]).Name);
            Assert.AreEqual(3, teamMemberCountAfter2);
            Assert.AreEqual(p2.Name, ((Player)myTeam.TeamPlayers[2]).Name);
        }
        [TestMethod]
        public void RemovesTeamMembers()
        {
            // arrange
            var mockSport = new Mock<ISport>();
            Player p1 = new Player("Adrian", 7, mockSport.Object);
            Player p2 = new Player("Luca", 22, mockSport.Object);
            myTeam.TeamPlayers.Add(p1);
            myTeam.TeamPlayers.Add(p2);
            int teamMembersCountOG = myTeam.TeamPlayers.Count, teamMemberCountAfter1;
            // act
            myTeam.TeamPlayers.Remove(p1);
            teamMemberCountAfter1 = myTeam.TeamPlayers.Count;

            // assert
            Assert.AreEqual(3, teamMembersCountOG);
            Assert.AreEqual(member1.Name, ((Player)myTeam.TeamPlayers[0]).Name);
            Assert.AreEqual(2, teamMemberCountAfter1);
            Assert.AreEqual(p2.Name, ((Player)myTeam.TeamPlayers[1]).Name);
        }
    }
}
