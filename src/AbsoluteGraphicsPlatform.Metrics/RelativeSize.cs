// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

// This file is forked from .NET Core library which is under MIT licensed.
// See https://github.com/dotnet/corefx

using System;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /// <summary>
    /// Represents the size of a rectangular region with an ordered pair of width and height.
    /// </summary>
    [Serializable]
    public struct RelativeSize : IEquatable<RelativeSize>
    {
        public static readonly RelativeSize Empty = new RelativeSize();

        private RelativeLength width;
        private RelativeLength height;

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeSize'/> class from the specified existing <see cref='RelativeSize'/>.
        /// </summary>
        public RelativeSize(RelativeSize size)
        {
            width = size.width;
            height = size.height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeSize'/> class from the specified <see cref='RelativePoint'/>.
        /// </summary>
        public RelativeSize(RelativePoint pt)
        {
            width = pt.X;
            height = pt.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeSize'/> class from the specified dimensions.
        /// </summary>
        public RelativeSize(RelativeLength width, RelativeLength height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Performs vector addition of two <see cref='RelativeSize'/> objects.
        /// </summary>
        public static RelativeSize operator +(RelativeSize sz1, RelativeSize sz2) => Add(sz1, sz2);

        /// <summary>
        /// Contracts a <see cref='RelativeSize'/> by another <see cref='RelativeSize'/>
        /// </summary>        
        public static RelativeSize operator -(RelativeSize sz1, RelativeSize sz2) => Subtract(sz1, sz2);

        /// <summary>
        /// Multiplies <see cref="RelativeSize"/> by a <see cref="float"/> producing <see cref="RelativeSize"/>.
        /// </summary>
        /// <param name="left">Multiplier of type <see cref="float"/>.</param>
        /// <param name="right">Multiplicand of type <see cref="RelativeSize"/>.</param>
        /// <returns>Product of type <see cref="RelativeSize"/>.</returns>
        public static RelativeSize operator *(float left, RelativeSize right) => Multiply(right, left);

        /// <summary>
        /// Multiplies <see cref="RelativeSize"/> by a <see cref="float"/> producing <see cref="RelativeSize"/>.
        /// </summary>
        /// <param name="left">Multiplicand of type <see cref="RelativeSize"/>.</param>
        /// <param name="right">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type <see cref="RelativeSize"/>.</returns>
        public static RelativeSize operator *(RelativeSize left, float right) => Multiply(left, right);

        /// <summary>
        /// Divides <see cref="RelativeSize"/> by a <see cref="float"/> producing <see cref="RelativeSize"/>.
        /// </summary>
        /// <param name="left">Dividend of type <see cref="RelativeSize"/>.</param>
        /// <param name="right">Divisor of type <see cref="int"/>.</param>
        /// <returns>Result of type <see cref="RelativeSize"/>.</returns>
        public static RelativeSize operator /(RelativeSize left, float right) => new RelativeSize(left.width / right, left.height / right);

        /// <summary>
        /// Tests whether two <see cref='RelativeSize'/> objects are identical.
        /// </summary>
        public static bool operator ==(RelativeSize sz1, RelativeSize sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        /// Tests whether two <see cref='RelativeSize'/> objects are different.
        /// </summary>
        public static bool operator !=(RelativeSize sz1, RelativeSize sz2) => !(sz1 == sz2);

        /// <summary>
        /// Converts the specified <see cref='RelativeSize'/> to a <see cref='RelativePoint'/>.
        /// </summary>
        public static explicit operator RelativePoint(RelativeSize size) => new RelativePoint(size.Width, size.Height);

        /// <summary>
        /// Tests whether this <see cref='RelativeSize'/> has zero width and height.
        /// </summary>
        public bool IsEmpty => width == RelativeLength.Zero && height == RelativeLength.Zero;

        /// <summary>
        /// Represents the horizontal component of this <see cref='RelativeSize'/>.
        /// </summary>
        public RelativeLength Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Represents the vertical component of this <see cref='RelativeSize'/>.
        /// </summary>
        public RelativeLength Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Performs vector addition of two <see cref='RelativeSize'/> objects.
        /// </summary>
        public static RelativeSize Add(RelativeSize sz1, RelativeSize sz2) => new RelativeSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        /// <summary>
        /// Contracts a <see cref='RelativeSize'/> by another <see cref='RelativeSize'/>.
        /// </summary>        
        public static RelativeSize Subtract(RelativeSize sz1, RelativeSize sz2) => new RelativeSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        /// <summary>
        /// Tests to see whether the specified object is a <see cref='RelativeSize'/> with the same dimensions as this <see cref='RelativeSize'/>.
        /// </summary>
        public override bool Equals(object obj) => obj is RelativeSize && Equals((RelativeSize)obj);

        public bool Equals(RelativeSize other) => this == other;

        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * Width.GetHashCode() *
                    19 * Height.GetHashCode();
            }
        }

        public RelativePoint ToRelativePoint() => (RelativePoint)this;

        /// <summary>
        /// Creates a human-readable string that represents this <see cref='RelativeSize'/>.
        /// </summary>
        public override string ToString() => $"{{Width={width}, Height={height}}}";

        /// <summary>
        /// Multiplies <see cref="RelativeSize"/> by a <see cref="float"/> producing <see cref="RelativeSize"/>.
        /// </summary>
        /// <param name="size">Multiplicand of type <see cref="RelativeSize"/>.</param>
        /// <param name="multiplier">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type RelativeSize.</returns>
        private static RelativeSize Multiply(RelativeSize size, float multiplier) => new RelativeSize(size.width * multiplier, size.height * multiplier);
    }
}
