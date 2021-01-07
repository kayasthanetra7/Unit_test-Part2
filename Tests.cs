using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{

    public static class MathExtensions
    {
        public static int PowerOf(int number, int powerOf)
        {
            var total = number;
            if (powerOf >= 1)
            {
                for (int i = 1; i < powerOf; i++)
                {

                    total = number * total;
                }
            }
            else if (powerOf == 0)
                return 1;

            else
                throw new InvalidOperationException("Cannot take the negative power of a number");

            return total;
        }
    }

    [TestClass]
    public class MathExtensionsTests
    {
        [TestMethod]
        public void PowerOf_numberIsPositive_returnTotal()
        {
            //arrange
            int number = 3;
            int powerOf = 3;
            int expected = 27;

            //act
            var result = MathExtensions.PowerOf(number, powerOf);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PowerOf_numberIsNegativeEvenPower_returnPositiveTotal()
        {
            //arrange
            int number = -2;
            int powerOf = 2;
            int expected = 4;

            //act
            var result = MathExtensions.PowerOf(number, powerOf);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PowerOf_numberIsNegativeOddPower_returnNegativeTotal()
        {
            //arrange
            int number = -3;
            int powerOf = 3;
            int expected = -27;

            //act
            var result = MathExtensions.PowerOf(number, powerOf);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PowerOf_numberIsZeroPower_returnOne()
        {
            //arrange
            int number = 3;
            int powerOf = 0;
            int expected = 1;

            //act
            var result = MathExtensions.PowerOf(number, powerOf);
            //assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void PowerOf_powerOfIsNegative_returnOne()
        {
            //arrange
            int number = 3;
            int powerOf = -2;
            var expectedExceptionMessage = "Cannot take the negative power of a number";

            //act
            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                MathExtensions.PowerOf(number, powerOf);
            });

            //assert
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        [TestMethod]
        public void PowerOf_powerOfIsOne_returnNumber()
        {
            //arrange
            int number = 3;
            int powerOf = 1;
            int expected = 3;

            // assert
            var result = MathExtensions.PowerOf(number, powerOf);

            //act
            Assert.AreEqual(expected, result);
        }

    }
}
