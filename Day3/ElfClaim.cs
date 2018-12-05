using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day3
{
    public sealed class ElfClaim : ValueObject
    {
        public int ClaimId { get; }
        public Rectangle Rectangle { get; }

        public ElfClaim(int claimId, Rectangle rectangle)
        {
            if (claimId <= 0)
                throw new ArgumentOutOfRangeException(nameof(claimId));

            ClaimId = claimId;
            Rectangle = rectangle ?? throw new ArgumentNullException(nameof(rectangle));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ClaimId;
            yield return Rectangle;
        }

        public override string ToString() => 
            $"#{ClaimId} @ {Rectangle}";
    }
}
