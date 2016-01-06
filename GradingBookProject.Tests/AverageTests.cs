using System;
using System.Collections.Generic;
using GradingBookProject.Maths;
using GradingBookProject.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradingBookProject.Tests
{
    [TestClass]
    public class AverageTests
    {
        [TestMethod]
        public void TestArthMean()
        {
            var rnd = new Random();
            List<SubjectDetailsViewModel> grades = new List<SubjectDetailsViewModel>();
            var sum = 0.0;
            for (var i = 0; i < 5; i++)
            {
                var val = rnd.Next(2, 6);
                var weight = rnd.Next(1, 10);
                var grade = new SubjectDetailsViewModel()
                {
                    grade_value = val,
                    grade_weight = weight
                };
                grades.Add(grade);
                sum += val;
            }
            var mean = Math.Round(sum/(grades.Count), 2);

            var calc = new AverageCalc();
            var result = calc.Average(grades.ToArray());

            Assert.AreEqual(mean, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no grade! (null)")]
        public void TestEmptyTableArth()
        {
            var calc = new AverageCalc();
            var emptyTable = new SubjectDetailsViewModel[1];
            var result = calc.Average(emptyTable);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no grade! (null)")]
        public void TestEmptyTableWeight()
        {
            var calc = new AverageCalc();
            var emptyTable = new SubjectDetailsViewModel[1];
            var result = calc.WeightedAverage(emptyTable);

        }

        [TestMethod]
        public void TestWeightedMean()
        {
            List<SubjectDetailsViewModel> grades = new List<SubjectDetailsViewModel>();
            var rnd = new Random();
            var sum = 0.0;
            var num = 0.0;

            for (var i = 0; i < 5; i++)
            {
                var val = rnd.Next(2, 6);
                var weight = rnd.Next(1, 10);
                var grade = new SubjectDetailsViewModel()
                {
                    grade_value = val,
                    grade_weight = weight
                };
                grades.Add(grade);
                sum += grade.grade_weight * grade.grade_value;
                num += grade.grade_weight;
            }
            var mean =Math.Round(sum/num, 2);

            var calc = new AverageCalc();
            var result = calc.WeightedAverage(grades.ToArray());

            Assert.AreEqual(mean, result);

        }
    }
}
