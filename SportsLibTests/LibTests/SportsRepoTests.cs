using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsLib.Interfaces;
using SportsLib.Models;
using Moq;
using System.Collections.Generic;

namespace SportsLibTests
{
    [TestClass]
    public class SportsRepoTests
    {
        // sport declarations
        ISport mySport;
        string sportsName = "Mock Sport Name";
        string sportsDesc = "Mock Sport Description";
        List<ITeam> testTeams;
        // team declarations
        Team AlphaTeam;
        string team1Name = "Alpha Team";
        Team BravoTeam;
        string team2Name = "Bravo Team";
        // team members declarations
        Player member1 = new Player("Mark", 16);
        Player member2 = new Player("Luca", 22);
        Player member3 = new Player("Josue", 9);
        Player member4 = new Player("Adrian", 13);
        // REPO declaration
        SportsRepo sportsRepo;

        public SportsRepoTests()
        {
            // sport definitions
            testTeams = new List<ITeam>();
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns(sportsName);
            mockSport.Setup(s => s.Description).Returns(sportsDesc);
            mockSport.Setup(s => s.SportTeams).Returns(testTeams);
            mySport = mockSport.Object;

            // team definitions
            AlphaTeam = new Team(mySport, team1Name);
            BravoTeam = new Team(mySport, team2Name);

            AlphaTeam.AddPlayer(member1);
            AlphaTeam.AddPlayer(member2);
            BravoTeam.AddPlayer(member3);
            BravoTeam.AddPlayer(member4);

            // insert into mockSport
            //testTeams.Add(AlphaTeam);
            //testTeams.Add(BravoTeam);

            // insert to 
            mySport.SportTeams.Add(AlphaTeam);
            mySport.SportTeams.Add(BravoTeam);

            sportsRepo = new SportsRepo(new List<ISport>() { mySport });
        }

        [TestMethod]
        public void GetsTeamCounts()
        {
            // arrange :: using ctor
            // act
            // assert
            Assert.AreEqual(1, sportsRepo.SportsList.Count); // total sports in repo
            Assert.AreEqual(2, sportsRepo.SportsList[0].SportTeams.Count); // total teams in sport
            Assert.AreEqual(2, sportsRepo.SportsList[0].SportTeams[0].TeamPlayers.Count); // total players in sport[0]
            Assert.AreEqual(2, sportsRepo.SportsList[0].SportTeams[1].TeamPlayers.Count); // total players in sport[1]
        }

        [TestMethod]
        public void AddSportToRepo()
        {
            // arrange
            int totalSportsOG = sportsRepo.SportsList.Count, totalSportsAfterInsert;
            string mockName = "test";
            string mockDesc = "desc";
            var myMockSport = new Mock<ISport>();
            myMockSport.Setup(s => s.Name).Returns(mockName);
            myMockSport.Setup(s => s.Description).Returns(mockDesc);
            myMockSport.Setup(s => s.SportTeams).Returns(new List<ITeam>());
            ISport sport = myMockSport.Object;

            // act
            sportsRepo.AddSport(sport);
            totalSportsAfterInsert = sportsRepo.SportsList.Count;

            // assert
            Assert.AreEqual(1, totalSportsOG);
            Assert.AreEqual(2, totalSportsAfterInsert);
        }

        [TestMethod]
        public void RemoveSportToRepo()
        {
            // arrange
            string mockName = "test";
            string mockDesc = "desc";
            var myMockSport = new Mock<ISport>();
            myMockSport.Setup(s => s.Name).Returns(mockName);
            myMockSport.Setup(s => s.Description).Returns(mockDesc);
            myMockSport.Setup(s => s.SportTeams).Returns(new List<ITeam>());
            ISport sport = myMockSport.Object;
            sportsRepo.AddSport(sport);

            int totalSportsOG = sportsRepo.SportsList.Count, totalSportsAfter;

            // act
            sportsRepo.RemoveSport(sport);
            totalSportsAfter = sportsRepo.SportsList.Count;

            // assert
            Assert.AreEqual(2, totalSportsOG);
            Assert.AreEqual(1, totalSportsAfter);
        }

    }
}
