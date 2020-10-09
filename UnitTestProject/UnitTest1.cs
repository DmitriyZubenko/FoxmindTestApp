using FoxmindTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            GetDefectiveAndMaxStringNumbers stringNumbers = new GetDefectiveAndMaxStringNumbers("c:\\test.txt");
            Assert.AreEqual(Constants.NoResultString, stringNumbers.GetMaxStringNumber(out List<int> defectiveStrings));
        }

        [Test]
        public void Test2()
        {
            GetDefectiveAndMaxStringNumbers stringNumbers = new GetDefectiveAndMaxStringNumbers(string.Empty);

            Assert.That(() => stringNumbers.GetMaxStringNumber(out List<int> defectiveStrings), Throws.TypeOf<Exception>());
        }
    }
}