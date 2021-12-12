using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsLib.Interfaces;
using SportsLib.Models;
using Moq;
using System.Collections.Generic;
using System;


namespace SportsLibTests
{
    [TestClass]
    public class SportTests
    {
        ISport mySport;
        string aSportName = "Test Sport Name";
        string aSportDescription = "Test Desc";
        List<ITeam> testTeams;

        Team DiamondDogs;
        string teamName = "DiamondDogs";

        public SportTests()
        {
            testTeams = new List<ITeam>();
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns(aSportName);
            mockSport.Setup(s => s.Description).Returns(aSportDescription);
            mockSport.Setup(s => s.SportTeams).Returns(testTeams);
            mySport = mockSport.Object;

            DiamondDogs = new Team(mySport, teamName);
        }

        [TestMethod]
        public void CreatesSport()
        {
            // arrange
            ISport sport;
            string sName = "Soccer", sDesc = "DESC OF SOCCER";
            var testSport = new Mock<ISport>();
            // act
            testSport.Setup(s => s.Name).Returns(sName);
            testSport.Setup(s => s.Description).Returns(sDesc);
            testSport.Setup(s => s.SportTeams).Returns(new List<ITeam>());
            sport = testSport.Object;
            // assert
            Assert.AreEqual(sName, sport.Name);
            Assert.AreEqual(sDesc, sport.Description);
            Assert.AreEqual(0, sport.SportTeams.Count);
        }

        [TestMethod]
        public void AddsTeamToList()
        {
            // arrange
            int teamCountOG = mySport.SportTeams.Count, teamCountAfterInsert1;
            // act
            mySport.AddSportTeam(DiamondDogs);
            teamCountAfterInsert1 = mySport.SportTeams.Count;
            // assert
            Assert.AreEqual(0, teamCountOG);
            Assert.AreEqual(1, teamCountAfterInsert1);
            Assert.AreEqual(DiamondDogs.Name, mySport.SportTeams[0].Name);
        }

        [TestMethod]
        public void RemovesTeamFromList()
        {
            // arrange
            int teamCountOG = mySport.SportTeams.Count, teamCountAfterInsert1, teamCountAfterRemoval;

            // act
            mySport.SportTeams.Add(DiamondDogs);
            teamCountAfterInsert1 = mySport.SportTeams.Count;
            mySport.SportTeams.Remove(DiamondDogs);
            teamCountAfterRemoval = mySport.SportTeams.Count;
            // assert
            Assert.AreEqual(0, teamCountOG);
            Assert.AreEqual(1, teamCountAfterInsert1);
            Assert.AreEqual(0, teamCountAfterRemoval);
        }
    }
}
