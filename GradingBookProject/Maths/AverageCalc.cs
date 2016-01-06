using GradingBookProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Maths
{
    /// <summary>
    /// Calculator for averages
    /// </summary>
    public class AverageCalc
    {
        /// <summary>
        /// Calculates a weighted average from given grades.
        /// </summary>
        /// <param name="grades">Array of grades as SubjectDetailsViewModel.</param>
        /// <returns></returns>
        public double WeightedAverage(SubjectDetailsViewModel[] grades)
        {

            if (grades != null)
            {
                if (grades.Length != 0)
                {
                    double sumTop = 0;
                    double sumBot = 0;
                    foreach (var grade in grades)
                    {
                        if (grade == null)
                            throw new Exception("There is no grade! (null)");

                        sumTop = sumTop + (grade.grade_value*grade.grade_weight);
                        sumBot = sumBot + (grade.grade_weight);
                    }

                    return Math.Round((sumTop/sumBot), 2);
                }
            }
            return 0;
        }

        /// <summary>
        /// Calculates average from given grades.
        /// </summary>
        /// <param name="grades">Array of grades as SubjectDetailsViewModel.</param>
        /// <returns></returns>
        public double Average(SubjectDetailsViewModel[] grades) 
        {
            double sum = 0;
            if (grades != null)
            {
                if (grades.Length != 0)
                {
                    foreach (var grade in grades)
                    {
                        if(grade == null)
                            throw new Exception("There is no grade! (null)");
                        sum = sum + grade.grade_value;
                    }
                    return Math.Round((sum/grades.Length),2);
                }
            }

            return 0;
        }
    }
}
