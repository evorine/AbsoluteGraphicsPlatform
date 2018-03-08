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
    public struct AbsoluteSize : IEquatable<AbsoluteSize>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> class.
        /// </summary>
        public static readonly AbsoluteSize Empty = new AbsoluteSize();
        private float width; // Do not rename (binary serialization) 
        private float height; // Do not rename (binary serialization) 

        /**
         * Create a new AbsoluteSize object from another size object
         */
        /// <summary>
        ///    Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> class
        ///    from the specified existing <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>.
        /// </summary>
        public AbsoluteSize(AbsoluteSize size)
        {
            width = size.width;
            height = size.height;
        }

        /**
         * Create a new AbsoluteSize object from a point
         */
        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> class from
        ///       the specified <see cref='AbsoluteGraphicsPlatform.Metrics.AbsolutePoint'/>.
        ///    </para>
        /// </summary>
        public AbsoluteSize(AbsolutePoint pt)
        {
            width = pt.X;
            height = pt.Y;
        }

        /**
         * Create a new AbsoluteSize object of the specified dimension
         */
        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> class from
        ///       the specified dimensions.
        ///    </para>
        /// </summary>
        public AbsoluteSize(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        ///    <para>
        ///       Performs vector addition of two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> objects.
        ///    </para>
        /// </summary>
        public static AbsoluteSize operator +(AbsoluteSize sz1, AbsoluteSize sz2) => Add(sz1, sz2);

        /// <summary>
        ///    <para>
        ///       Contracts a <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> by another <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>
        ///    </para>
        /// </summary>        
        public static AbsoluteSize operator -(AbsoluteSize sz1, AbsoluteSize sz2) => Subtract(sz1, sz2);

        /// <summary>
        /// Multiplies <see cref="AbsoluteSize"/> by a <see cref="float"/> producing <see cref="AbsoluteSize"/>.
        /// </summary>
        /// <param name="left">Multiplier of type <see cref="float"/>.</param>
        /// <param name="right">Multiplicand of type <see cref="AbsoluteSize"/>.</param>
        /// <returns>Product of type <see cref="AbsoluteSize"/>.</returns>
        public static AbsoluteSize operator *(float left, AbsoluteSize right) => Multiply(right, left);

        /// <summary>
        /// Multiplies <see cref="AbsoluteSize"/> by a <see cref="float"/> producing <see cref="AbsoluteSize"/>.
        /// </summary>
        /// <param name="left">Multiplicand of type <see cref="AbsoluteSize"/>.</param>
        /// <param name="right">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type <see cref="AbsoluteSize"/>.</returns>
        public static AbsoluteSize operator *(AbsoluteSize left, float right) => Multiply(left, right);

        /// <summary>
        /// Divides <see cref="AbsoluteSize"/> by a <see cref="float"/> producing <see cref="AbsoluteSize"/>.
        /// </summary>
        /// <param name="left">Dividend of type <see cref="AbsoluteSize"/>.</param>
        /// <param name="right">Divisor of type <see cref="int"/>.</param>
        /// <returns>Result of type <see cref="AbsoluteSize"/>.</returns>
        public static AbsoluteSize operator /(AbsoluteSize left, float right)
            => new AbsoluteSize(left.width / right, left.height / right);

        /// <summary>
        ///    Tests whether two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> objects
        ///    are identical.
        /// </summary>
        public static bool operator ==(AbsoluteSize sz1, AbsoluteSize sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        ///    <para>
        ///       Tests whether two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> objects are different.
        ///    </para>
        /// </summary>
        public static bool operator !=(AbsoluteSize sz1, AbsoluteSize sz2) => !(sz1 == sz2);

        /// <summary>
        ///    <para>
        ///       Converts the specified <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> to a
        ///    <see cref='AbsoluteGraphicsPlatform.Metrics.AbsolutePoint'/>.
        ///    </para>
        /// </summary>
        public static explicit operator AbsolutePoint(AbsoluteSize size) => new AbsolutePoint(size.Width, size.Height);

        /// <summary>
        ///    <para>
        ///       Tests whether this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> has zero
        ///       width and height.
        ///    </para>
        /// </summary>
        public bool IsEmpty => width == 0 && height == 0;

        /**
         * Horizontal dimension
         */

        /// <summary>
        ///    <para>
        ///       Represents the horizontal component of this
        ///    <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>.
        ///    </para>
        /// </summary>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        /**
         * Vertical dimension
         */

        /// <summary>
        ///    <para>
        ///       Represents the vertical component of this
        ///    <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>.
        ///    </para>
        /// </summary>
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        ///    <para>
        ///       Performs vector addition of two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> objects.
        ///    </para>
        /// </summary>
        public static AbsoluteSize Add(AbsoluteSize sz1, AbsoluteSize sz2) => new AbsoluteSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        /// <summary>
        ///    <para>
        ///       Contracts a <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> by another <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>
        ///       .
        ///    </para>
        /// </summary>        
        public static AbsoluteSize Subtract(AbsoluteSize sz1, AbsoluteSize sz2) => new AbsoluteSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        /// <summary>
        ///    <para>
        ///       Tests to see whether the specified object is a
        ///    <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/> 
        ///    with the same dimensions as this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>.
        /// </para>
        /// </summary>
        public override bool Equals(object obj) => obj is AbsoluteSize && Equals((AbsoluteSize)obj);

        public bool Equals(AbsoluteSize other) => this == other;

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

        public AbsolutePoint ToAbsolutePoint() => (AbsolutePoint)this;

        /// <summary>
        ///    <para>
        ///       Creates a human-readable string that represents this
        ///    <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteSize'/>.
        ///    </para>
        /// </summary>
        public override string ToString() => "{Width=" + width.ToString() + ", Height=" + height.ToString() + "}";

        /// <summary>
        /// Multiplies <see cref="AbsoluteSize"/> by a <see cref="float"/> producing <see cref="AbsoluteSize"/>.
        /// </summary>
        /// <param name="size">Multiplicand of type <see cref="AbsoluteSize"/>.</param>
        /// <param name="multiplier">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type AbsoluteSize.</returns>
        private static AbsoluteSize Multiply(AbsoluteSize size, float multiplier) =>
            new AbsoluteSize(size.width * multiplier, size.height * multiplier);
    }
}
