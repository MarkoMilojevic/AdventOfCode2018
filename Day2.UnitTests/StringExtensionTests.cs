using Xunit;
using static FileExtensions.FileExtensions;

namespace Day2.UnitTests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("abcdef", 2, false)]
        [InlineData("abcdef", 3, false)]
        [InlineData("bababc", 2, true)]
        [InlineData("bababc", 3, true)]
        [InlineData("abbcde", 2, true)]
        [InlineData("abbcde", 3, false)]
        [InlineData("abcccd", 2, false)]
        [InlineData("abcccd", 3, true)]
        [InlineData("aabcdd", 2, true)]
        [InlineData("aabcdd", 3, false)]
        [InlineData("abcdee", 2, true)]
        [InlineData("abcdee", 3, false)]
        [InlineData("ababab", 2, false)]
        [InlineData("ababab", 3, true)]
        public void ContainsLetterTests(string input, int numberOfOccurrences, bool expected) => 
            Assert.Equal(expected, input.ContainsAnyLetterExactNumberOfOccurences(numberOfOccurrences));

        [Fact]
        public void ChecksumTests() => 
            Assert.Equal(12, new[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }.Checksum());


        [Fact]
        public void IntegrationTestPartOne() =>
            Assert.Equal(8118, ReadStringArrayFromFile("day2_one.txt").Checksum());
    }
}
