using System.Collections.Generic;
using System.Linq;
using FunctionalExtensions;
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
            Assert.Equal(expected, input.ContainsAnyLetterExactNumberOfOccurrences(numberOfOccurrences));

        [Fact]
        public void ChecksumTests() =>
            Assert.Equal(12, new[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }.Checksum());


        [Fact]
        public void IntegrationTestPartOne() =>
            Assert.Equal(8118, ReadStringArrayFromFile("day2_one.txt").Checksum());

        [Fact]
        public void CommonAfterRemovingDifferingCharacterTest() =>
            Assert.Equal("fgij", "fghij".CommonAfterRemovingDifferingCharacter("fguij").Reduce((string) null));

        [Fact]
        public void IntegrationTestPartTwo()
        {
            var result = new List<Option<string>>();
            string[] ids = ReadStringArrayFromFile("day2_two.txt");

            for (int i = 0; i < ids.Length - 1; i++)
            {
                string first = ids[i];
                for (int j = i + 1; j < ids.Length; j++)
                {
                    string second = ids[j];
                    result.Add(first.CommonAfterRemovingDifferingCharacter(second));
                }
            }

            Assert.Equal("jbbenqtlaxhivmwyscjukztdp", result.OfType<Some<string>>().Single().Reduce((string) null));
        }
    }
}
