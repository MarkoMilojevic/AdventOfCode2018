using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day3
{
    public sealed class Rectangle : ValueObject
    {
        public int TopLeftX { get; }
        public int TopLeftY { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int topLeftX, int topLeftY, int width, int height)
        {
            if (topLeftX < 0)
                throw new ArgumentOutOfRangeException(nameof(topLeftX));
            if (topLeftY < 0)
                throw new ArgumentOutOfRangeException(nameof(topLeftY));
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));

            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            Width = width;
            Height = height;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TopLeftX;
            yield return TopLeftY;
            yield return Width;
            yield return Height;
        }

        public override string ToString() => 
            $"{TopLeftX},{TopLeftY}: {Width}x{Height}";
    }
}
