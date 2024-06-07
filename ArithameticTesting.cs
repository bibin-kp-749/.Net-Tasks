using SampleXUnitTest.Model;
using SampleXUnitTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest
{
    public class ArithameticTesting
    {
        [Fact]
        public void ArithameticOperations_AddTwoNumber_returnnum()
        {
            //arrange
            var maths=new ArithameticOperations();
            int num1=10, num2=10;
            //act
            var result=maths.AddTwoNumber(num1, num2);
            //assert
            Assert.True(result != 0);
        }
        [Theory]
        [InlineData(10,10,true)]
        [InlineData(20,20,true)]
        [InlineData(0,0,false)]
        public void ArithameticOperations_AddTwoNumberUsingInlineData_returnnum(int num1,int num2,bool expected)
        {
            //arrange
            var maths=new ArithameticOperations();
            //act
            var result=maths.AddTwoNumber(num1 , num2);
            //assert
            Assert.Equal(result!=0,expected);
        }
        [Theory]
        [MemberData(nameof(Numbers.numbers),MemberType =typeof(Numbers))]
        public void ArithameticOperations_AddTwoNumberUsingMemeberData_returnnum(int num1,int num2,bool expected)
        {
            //arrange
            var maths=new ArithameticOperations();
            //act
            var result = maths.AddTwoNumber(num1, num2);
            //Assert
            Assert.Equal(result!=0,expected);
        }
    }
}
