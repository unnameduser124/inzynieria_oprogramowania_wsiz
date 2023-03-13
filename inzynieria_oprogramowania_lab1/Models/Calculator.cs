using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace inzynieria_oprogramowania_lab1.Models
{
    class Calculator
    {
        public static double add(double x, double y)
        {
            return x + y;
        }
        public static double subtract(double x, double y)
        {
            return x - y;
        }
        public static double multiply(double x, double y)
        {
            return x * y;
        }
        public static double divide(double x, double y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine(error.Message);
                throw new DivideByZeroException();
            }
        }

             
    }

    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2.4, 2, 4.4)]
        [InlineData(10.6, 2.2, 12.8)]
        [InlineData(25, 17, 42)]
        [InlineData(1.5, 2.4, 3.9)]
        public void AdditionTest(double x, double y, double result)
        {
            Assert.Equal(result, Calculator.add(x, y), 2);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(2.4, 2, 0.4)]
        [InlineData(10.6, 2.2, 8.4)]
        [InlineData(25, 17, 8)]
        [InlineData(1.5, 2.4, -0.9)]
        public void SubtractionTest(double x, double y, double result)
        {
            Assert.Equal(result, Calculator.subtract(x, y), 2);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2.4, 0, 0)]
        [InlineData(10.6, 2.2, 23.32)]
        [InlineData(25, 17, 425)]
        [InlineData(1.5, 2.4, 3.6)]
        public void MultiplicationTest(double x, double y, double result)
        {
            Assert.Equal(result, Calculator.multiply(x, y), 2);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(2.4, 2, 1.2)]
        [InlineData(10.6, 2.5, 4.24)]
        [InlineData(25, 17, 1.47)]
        [InlineData(1.5, 2.4, 0.625)]
        public void DivisionTest(double x, double y, double result)
        {
            Assert.Equal(result, Calculator.divide(x, y), 2);
        }

    }

}
