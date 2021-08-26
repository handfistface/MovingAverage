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
    }
}
