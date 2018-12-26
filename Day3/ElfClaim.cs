using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day3
{
    public sealed class ElfClaim : ValueObject
    {
        public int Id { get; }
        public Rectangle Rectangle { get; }

        public ElfClaim(int id, Rectangle rectangle)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
            Rectangle = rectangle ?? throw new ArgumentNullException(nameof(rectangle));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Rectangle;
        }

        public override string ToString() => 
            $"#{Id} @ {Rectangle}";
    }
}
