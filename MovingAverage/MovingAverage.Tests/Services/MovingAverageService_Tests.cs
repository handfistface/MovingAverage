using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovingAverage.Etc.Services;
using MovingAverage.Tests.Asserters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage.Tests.Services
{
    /// <summary>
    ///     Tests the MovingAverage class
    /// </summary>
    [TestClass]
    public class MovingAverageService_Tests
    {
        #region Compute_3()
        [TestMethod]
        public void Compute_3()
        {
            //'fixture' data
            double[] toCalc = new double[] { 0, 1, 2, 3 };
            double[] expected = new double[] { 0, 0.5, 1, 2 };

            //setup the averager
            MovingAverageService averager = new MovingAverageService();
            averager.WindowSize = 3;
            averager.AddValues(toCalc);

            //calculate the averages
            double[] actual = averager.CalculateAverage().ToArray();

            //assert the values
            DoubleArrayAsserter asserter = new DoubleArrayAsserter();
            asserter.AreEqual(expected, actual);
        }
        #endregion

        #region Compute_5()
        [TestMethod]
        public void Compute_5()
        {
            //'fixture' data
            double[] toCalc = new double[] { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            double[] expected = new double[] { 0, 0.5, -0.3333333333333333, 0.5, -0.4, 0.6, -0.8, 1, -1.2, 1.4 };

            //setup the averager
            MovingAverageService averager = new MovingAverageService();
            averager.WindowSize = 5;
            averager.AddValues(toCalc);

            //calculate the averages
            double[] actual = averager.CalculateAverage().ToArray();

            //assert the values
            DoubleArrayAsserter asserter = new DoubleArrayAsserter();
            asserter.AreEqual(expected, actual);
        }
        #endregion
    }
}
