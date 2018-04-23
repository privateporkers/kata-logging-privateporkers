using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham")]
        public void ShouldParse(string line)
        {
			//Arrange
			var parser = new TacoParser();
			//Act
			var result = parser.Parse(line);
			//Aserrt
			Assert.NotNull(result.Name);
			Assert.NotNull(result.Location);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
		[InlineData("1234, 1234")]
		[InlineData("1234, 1234, Location, Other")]
		[InlineData("-190.05, 85.50, Location")]
		[InlineData("170.02, 100.20, Location")]
		public void ShouldFailParse(string line)
        {
			//Arrange  
			var parser = new TacoParser();
			ITrackable expected = null;
			//Act
			var actual = parser.Parse(line);
			//Assert
			Assert.Equal(actual, expected);
        }
    }
}
