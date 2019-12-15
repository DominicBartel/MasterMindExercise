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
        public void LastAttemptWrongPosition()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SetCorrectNumbers("1234");
            masterMindTest.SolveAttempt("4321");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "----");
        }
        [TestMethod()]
        public void LastAttemptThreeCorrectPosition()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SetCorrectNumbers("1234");
            masterMindTest.SolveAttempt("1233");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "+++");
        }
        [TestMethod()]
        public void LastAttemptThreeIncorrecttPosition()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SetCorrectNumbers("1234");
            masterMindTest.SolveAttempt("3126");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "---");
        }
        [TestMethod()]
        public void LastAttemptTwoIncorrecttPositionOneCorrect()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SetCorrectNumbers("1234");
            masterMindTest.SolveAttempt("3164");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "+--");
        }
        [TestMethod()]
        public void LastAttemptFailsLongInput()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("11111");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "");
        }
        [TestMethod()]
        public void LastAttemptFailsIncorrectRange()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("7777");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "");
        }
        [TestMethod()]
        public void LastAttemptFailsNotNumbers()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            masterMindTest.SolveAttempt("ASDF");
            Assert.IsTrue(masterMindTest.LastAttemptResults() == "");
        }


    }
    [TestClass]
    public class GoodAttemptTests
    {
        [TestMethod()]
        public void GoodAttemptReturnsTrue()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            Assert.IsTrue(masterMindTest.GoodAttempt("1111"));
        }
        [TestMethod()]
        public void LongInputReturnsFalse()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            Assert.IsFalse(masterMindTest.GoodAttempt("11111"));
        }
        [TestMethod()]
        public void TextInputReturnsFalse()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            Assert.IsFalse(masterMindTest.GoodAttempt("ASDF"));
        }
        [TestMethod()]
        public void ShortInputReturnsFalse()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            Assert.IsFalse(masterMindTest.GoodAttempt("12"));
        }
        [TestMethod()]
        public void IncorrectRangeReturnsFalse()
        {
            MasterMindGame masterMindTest = new MasterMindGame(6, 2);
            Assert.IsFalse(masterMindTest.GoodAttempt("7777"));
        }

    }


}