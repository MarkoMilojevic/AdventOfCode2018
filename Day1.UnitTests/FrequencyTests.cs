using Xunit;
using static FileExtensions.FileExtensions;

namespace Day1.UnitTests
{
    public class FrequencyTests
    {
        [Theory]
        [InlineData(new[] { 1, 1, 1 }, 3)]
        [InlineData(new[] { 1, 1, -2 }, 0)]
        [InlineData(new[] { -1, -2, -3 }, -6)]
        public void CalibrateTests(int[] deltas, int expected) => 
            Assert.Equal(expected, Frequency.Zero.Calibrate(deltas));

        [Fact]
        public void IntegrationTestPartOne() => 
            Assert.Equal(423, Frequency.Zero.Calibrate(ReadIntArrayFromFile("day1_one.txt")));

        [Theory]
        [InlineData(new[] { 1, -1 }, 0)]
        [InlineData(new[] { 3, 3, 4, -2, -4 }, 10)]
        [InlineData(new[] { -6, 3, 8, 5, -6 }, 5)]
        [InlineData(new[] { 7, 7, -2, -7, -4 }, 14)]
        public void CalibrateUntilRepeated(int[] deltas, int expected) =>
            Assert.Equal(expected, Frequency.Zero.CalibrateUntilRepeated(deltas));

        [Fact]
        public void IntegrationTestPartTwo() =>
            Assert.Equal(61126, Frequency.Zero.CalibrateUntilRepeated(ReadIntArrayFromFile("day1_two.txt")));
    }
}
