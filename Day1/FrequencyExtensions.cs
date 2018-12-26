using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public static class FrequencyExtensions
    {
        public static Frequency Calibrate(this Frequency frequency, int delta) => 
            new Frequency(frequency + delta);

        public static Frequency Calibrate(this Frequency frequency, int[] deltas) => 
            deltas.Aggregate(frequency, (current, delta) => current.Calibrate(delta));

        public static Frequency CalibrateUntilRepeated(this Frequency frequency, int[] deltas)
        {
            var seen = new HashSet<Frequency> { frequency };

            foreach (int delta in deltas.Circular())
            {
                frequency = frequency.Calibrate(delta);
                if (seen.Contains(frequency))
                    return frequency;

                seen.Add(frequency);
            }

            return frequency;
        }
    }
}
