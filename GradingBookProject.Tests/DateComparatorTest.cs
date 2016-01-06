using System;
using GradingBookProject.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradingBookProject.Tests
{
    [TestClass]
    public class DateComparatorTest
    {
        [TestMethod]
        public void TestComparison()
        {
            var time1 = DateTime.Now;
            var time2 = DateTime.Now;
            var time3 = time2.AddDays(3);
            var time4 = time2.AddMinutes(2);
            
            
            Comparator comparator = new Comparator();
            var result1 = comparator.isLater(time1,time2);
            var result2 = comparator.isLater(time1, time3);
            var result3 = comparator.isLater(time4, time2);

            Assert.AreEqual(time1, result1);
            Assert.AreEqual(time3, result2);
            Assert.AreEqual(time4,result3);
        }
    }
}
