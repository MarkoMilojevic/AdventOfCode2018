using System;
using System.Linq;

namespace Day3
{
    public class Fabric
    {
        private int[][] ClaimedPositions { get; }

        public Fabric()
        {
            ClaimedPositions = new int[1000][];
            for (int i = 0; i < ClaimedPositions.Length; i++)
            {
                ClaimedPositions[i] = new int[1000];
                for (int j = 0; j < ClaimedPositions[i].Length; j++)
                {
                    ClaimedPositions[i][j] = 0;
                }
            }
        }

        public void MakeClaim(ElfClaim claim)
        {
            if (claim == null)
                throw new ArgumentNullException(nameof(claim));
            
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
                for (int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                    ClaimedPositions[i][j] += 1;
        }

        public int TotalOverlappingArea() =>
            ClaimedPositions.Sum(row => row.Count(numberOfClaims => numberOfClaims > 1));

        public bool IsOverlapping(ElfClaim claim)
        {
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
                for (int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                    if (ClaimedPositions[i][j] > 1)
                        return true;

            return false;
        }
    }
}
