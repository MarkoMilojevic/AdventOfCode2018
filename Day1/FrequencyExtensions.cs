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

        public static Frequency CalibrateUntilFrequencyNotRepeated(this Frequency frequency, int[] changes)
        {
            var seen = new HashSet<Frequency> { frequency };

            while (true)
            {
                foreach (int change in changes)
                {
                    frequency = frequency.Calibrate(change);
                    if (seen.Contains(frequency))
                        return frequency;

                    seen.Add(frequency);
                }
            }
        }
    }
}
