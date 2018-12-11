using System.Collections.Generic;
using Xunit;
using static Day3.ElfClaimReaderExtensions;

namespace Day3.UnitTests
{
    public class ElfClaimReaderExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ParseClaimTestsParams))]
        public void ParseElfClaimTests(string line, ElfClaim expected) =>
            Assert.Equal(expected, ParseElfClaim(line));

        public static IEnumerable<object[]> ParseClaimTestsParams()
        {
            yield return new object[] { "#1 @ 49,222: 19x20", new ElfClaim(1, new Rectangle(49, 222, 19, 20)) };
            yield return new object[] { "#2 @ 162,876: 28x29", new ElfClaim(2, new Rectangle(162, 876, 28, 29)) };
            yield return new object[] { "#3 @ 28,156: 17x18", new ElfClaim(3, new Rectangle(28, 156, 17, 18)) };
        }

        [Theory]
        [InlineData("#1 @ 49,222: 19x20", 1)]
        [InlineData("#2 @ 162,876: 28x29", 2)]
        [InlineData("#3 @ 28,156: 17x18", 3)]
        public void ExtractElfClaimIdTests(string line, int expectedClaimId) => 
            Assert.Equal(expectedClaimId, ExtractElfClaimId(line));
        
        [Theory]
        [InlineData("#1 @ 49,222: 19x20", 49, 222)]
        [InlineData("#2 @ 162,876: 28x29", 162, 876)]
        [InlineData("#3 @ 28,156: 17x18", 28, 156)]
        public void ExtractElfClaimRectangleTopLeftCoordinatesTests(string line, int expectedX, int expectedY)
        {
            (int topLeftX, int topLeftY) = ExtractElfClaimRectangleTopLeftCoordinates(line);

            Assert.Equal(expectedX, topLeftX);
            Assert.Equal(expectedY, topLeftY);
        }

        [Theory]
        [InlineData("#1 @ 49,222: 19x20", 19, 20)]
        [InlineData("#2 @ 162,876: 28x29", 28, 29)]
        [InlineData("#3 @ 28,156: 17x18", 17, 18)]
        public void ExtractElfClaimRectangleDimensionsTests(string line, int expectedWidth, int expectedHeight)
        {
            (int width, int height) = ExtractElfClaimRectangleDimensions(line);

            Assert.Equal(expectedWidth, width);
            Assert.Equal(expectedHeight, height);
        }
    }
}
