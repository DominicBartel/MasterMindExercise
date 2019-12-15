using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Tests
{
    [TestClass]
    public class SolveAttemptTests
    {
        [TestMethod()]
        public void SolveAttemptGoodEntry()
        {
            MasterMindGame masterMindTest = new MasterMindGame(1, 1);
            masterMindTest.SolveAttempt("1111");
            Assert.IsTrue(masterMindTest.GoodEntry == true);
        }

        [TestMethod()]
        public void SolveAttemptLongEntry()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 1);
            masterMindTest.SolveAttempt("12341");
            Assert.IsTrue(masterMindTest.GoodEntry == false);
        }
        [TestMethod()]
        public void SolveAttemptNotNumbers()
        {
            MasterMindGame masterMindTest = new MasterMindGame(1, 1);
            masterMindTest.SolveAttempt("ASDF");
            Assert.IsTrue(masterMindTest.GoodEntry == false);
        }
        
    }
    [TestClass]
    public class LastAttemptTests
    {
        [TestMethod()]
        public void LastAttemptCanWin()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt(masterMindTest.CorrectNumbers);
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "++++");
        }
        [TestMethod()]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void LastAttemptFailsLongInput()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("11111");
        }
        [TestMethod()]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void LastAttemptFailsIncorrectRange()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("7777");
        }
        [TestMethod()]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void LastAttemptFailsNotNumbers()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("ASDF");
        }
    }

}