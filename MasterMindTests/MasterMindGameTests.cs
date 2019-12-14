using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Tests
{
    [TestClass()]
    public class MasterMindGameTests
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
        [TestMethod()]
        public void LastAttemptCanWin()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt(masterMindTest.CorrectNumbers);
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "++++");
        }
    }
}