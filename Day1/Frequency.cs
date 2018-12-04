using System.Collections.Generic;
using FunctionalExtensions;

namespace Day1
{
    public sealed class Frequency : ValueObject
    {
        public static Frequency Zero { get; } = new Frequency(0);

        private int Value { get; }

        public Frequency(int value) => 
            Value = value;
        
        public static implicit operator int(Frequency frequency) =>
            frequency.Value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override string ToString() => 
            $"{Value}";
    }
}
