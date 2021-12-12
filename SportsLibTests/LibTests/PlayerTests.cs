using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsLib.Interfaces;
using SportsLib.Models;
using Moq;
using System.Collections.Generic;

namespace SportsLibTests
{
    [TestClass]
    public class PlayerTests
    {
        Player myPlayer;
        string personName = "Mark";
        int rosterNum = 16;

        public PlayerTests()
        {
            myPlayer = new Player(personName, rosterNum);
        }

        [TestMethod]
        public void GetsPlayerInformation()
        {
            Assert.AreEqual(personName, myPlayer.Name);
            Assert.AreEqual(rosterNum, myPlayer.RosterNumber);
        }

        [TestMethod]
        public void ChangesPlayerRosterNumber()
        {
            int rosterBeforeChange = myPlayer.RosterNumber, rosterAfterChange = 32;
            Assert.AreEqual(rosterBeforeChange, myPlayer.RosterNumber);

            myPlayer.UpdateRosterNumber(rosterAfterChange);
            Assert.AreEqual(rosterAfterChange, myPlayer.RosterNumber);
        }
        [TestMethod]
        public void ChangesPlayerName()
        {
            string nameBeforeChange = myPlayer.Name, nameAfterChange = "Josue";
            Assert.AreEqual(nameBeforeChange, myPlayer.Name);

            myPlayer.Name = nameAfterChange;
            Assert.AreEqual(nameAfterChange, myPlayer.Name);
        }
    }
}
