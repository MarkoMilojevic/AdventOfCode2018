using System.Collections.Generic;
using System.Linq;
using static FileExtensions.FileExtensions;

namespace Day3
{
    public static class ElfClaimReaderExtensions
    {
        public static IEnumerable<ElfClaim> ReadElfClaimsFromFile(string filePath) => 
            ReadStringArrayFromFile(filePath).Select(ParseClaim);

        public static ElfClaim ParseClaim(string line) => 
            new ElfClaim(ExtractClaimId(line), ExtractClaimRectangle(line));

        public static int ExtractClaimId(string line) => 
            int.Parse(line.Split('@')[0].Substring(1).Trim());

        public static Rectangle ExtractClaimRectangle(string line)
        {
            (int topLeftX, int topLeftY) = ExtractClaimRectangleTopLeftCoordinates(line);
            (int width, int height) = ExtractClaimRectangleDimensions(line);

            return new Rectangle(topLeftX, topLeftY, width, height);
        }

        public static (int topLeftX, int topLeftY) ExtractClaimRectangleTopLeftCoordinates(string line)
        {
            string[] coordinates = line.Split('@')[1].Split(':')[0].Trim().Split(',');

            return (int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }

        public static (int width, int height) ExtractClaimRectangleDimensions(string line)
        {
            string[] dimensions = line.Split(':')[1].Trim().Split('x');

            return (int.Parse(dimensions[0]), int.Parse(dimensions[1]));
        }
    }
}
