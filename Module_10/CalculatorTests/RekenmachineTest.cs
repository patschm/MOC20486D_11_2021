using CalcLib;
using System;
using Xunit;

namespace CalculatorTests
{
    public class RekenmachineTest
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2, 3, 5)]
        [InlineData(4, 3, 7)]
        public void TestTelop(int a, int b, int expected)
        {
            // Arrange
            RekenMachine mach = new RekenMachine();
            //int expected = 7;

            // Act
            int actual = mach.Telop(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrekaf()
        {
            // Arrange
            RekenMachine mach = new RekenMachine();
            int expected = -1;

            // Act
            int actual = mach.Trekaf(3, 4);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
