using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage.Tests.Asserters
{
    /// <summary>
    ///     Asserts double arrays
    /// </summary>
    public class DoubleArrayAsserter
    {
        #region AreEqual(double[] expected, double[] actual)
        /// <summary>
        ///     Asserts that both arrays have values that are the same in the same order
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public void AreEqual(double[] expected, double[] actual)
        {
            //make sure the lengths are the same
            Assert.AreEqual(expected.Length, actual.Length);

            //go through each double in the array and assert their values
            for(int i=0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        #endregion
    }
}
