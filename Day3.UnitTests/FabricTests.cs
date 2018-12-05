using System.Linq;
using Xunit;
using static Day3.ElfClaimReaderExtensions;

namespace Day3.UnitTests
{
    public class FabricTests
    {
        [Fact]
        public void TotalOverlappingAreaTests()
        {
            var fabric = new Fabric();
            var claimLines = new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
            var claims = claimLines.Select(ParseClaim);

            foreach (ElfClaim elfClaim in claims)
                fabric.MakeClaim(elfClaim);

            Assert.Equal(4, fabric.TotalOverlappingArea());
        }

        [Fact]
        public void IntegrationTestPartOne()
        {
            var fabric = new Fabric();
            var claims = ReadElfClaimsFromFile("day3_one.txt");

            foreach (ElfClaim elfClaim in claims)
                fabric.MakeClaim(elfClaim);

            Assert.Equal(110195, fabric.TotalOverlappingArea());
        }

        [Fact]
        public void IsOverlappingTests()
        {
            var fabric = new Fabric();
            var claimLines = new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
            var claims = claimLines.Select(ParseClaim).ToArray();

            foreach (ElfClaim elfClaim in claims)
                fabric.MakeClaim(elfClaim);

            Assert.True(fabric.IsOverlapping(claims[0]));
            Assert.True(fabric.IsOverlapping(claims[1]));
            Assert.False(fabric.IsOverlapping(claims[2]));
        }

        [Fact]
        public void IntegrationTestPartTwo()
        {
            var fabric = new Fabric();
            var claims = ReadElfClaimsFromFile("day3_two.txt").ToArray();

            foreach (ElfClaim elfClaim in claims)
                fabric.MakeClaim(elfClaim);

            ElfClaim notOverlapping = claims.Single(claim => !fabric.IsOverlapping(claim));

            Assert.Equal(894, notOverlapping.ClaimId);
        }

    }
}
