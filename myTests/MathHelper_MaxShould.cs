using System;
using Xunit;
using myLib;

namespace myTests
{
    public class MathHelper_MaxShould
    {
        //This object (instance of MathHelper) will be tested in all functions in this class (MathHelper_MaxShould)
        private readonly MathHelper _mathHelper;

        public MathHelper_MaxShould()
        {
            //Initalaizing allways, because we will use it for all tests in this class
            _mathHelper  = new MathHelper();
        }

        [Fact]

        ///Fact tests one valume (invariant- never changing conditions)
        public void Return0GivenValuesOf0()
        {
            //Checking what will function return as result if looking for max from 0 and 0
            var result = _mathHelper.Max(0,0);
            
            //If result not equal to 0, throw error
            Assert.Equal(0,result);
        }

        [Theory]

        ///Theory tests multiple datasets
        [InlineDataAttribute(89,89,89)]
        [InlineDataAttribute(-897,-897,-897)]
        [InlineDataAttribute(1,289,289)]
        [InlineDataAttribute(-89,89,89)]
        [InlineDataAttribute(89,-89,89)]
        [InlineDataAttribute(0,0,0)]
        public void ReturnValueWhenValueOfOperandsSame(int value1, int value2, int expectedResult)
        {
            var result = _mathHelper.Max(value1,value2);
            Assert.Equal(expectedResult,result);
        }
        
        ///Another example showing how to test if Max(A,B) = MAX(B,A)
        [Fact]
        public void ReturnSameResultIndependentFromOrder()
        {
            //Arrange two random numbers to test values
            Random rnd = new Random();
            int testValue1 = rnd.Next();
            int testValue2 = rnd.Next();

            // Act
            var result1 = _mathHelper.Max(testValue1,testValue2);
            var result2 = _mathHelper.Max(testValue2,testValue1);

            // Assert
            Assert.Equal(result1,result2);
        }
    }
}
