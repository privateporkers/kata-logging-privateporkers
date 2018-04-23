using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("Example")]
        public void ShouldParse(string str)
        {
            //Arrange

            //act

            //assert
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            //Arrange

            //act

            //assert
        }
    }
}
