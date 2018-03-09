// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

// This file is forked from .NET Core library which is under MIT licensed.
// See https://github.com/dotnet/corefx

using System;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /// <summary>
    /// Represents an ordered pair of x and y coordinates that define a point in a two-dimensional plane.
    /// </summary>
    [Serializable]
    public struct RelativePoint : IEquatable<RelativePoint>
    {
        public static readonly RelativePoint Empty = new RelativePoint();

        private RelativeLength x;
        private RelativeLength y;

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativePoint'/> class with the specified coordinates.
        /// </summary>
        public RelativePoint(RelativeLength x, RelativeLength y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref='RelativePoint'/> is empty.
        /// </summary>
        public bool IsEmpty => x == 0f && y == 0f;

        /// <summary>
        /// Gets the x-coordinate of this <see cref='RelativePoint'/>.
        /// </summary>
        public RelativeLength X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets the y-coordinate of this <see cref='RelativePoint'/>.
        /// </summary>
        public RelativeLength Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Translates a <see cref='RelativePoint'/> by a given <see cref='RelativeSize'/> .
        /// </summary>
        public static RelativePoint operator +(RelativePoint pt, RelativeSize sz) => Add(pt, sz);

        /// <summary>
        /// Translates a <see cref='RelativePoint'/> by the negative of a given <see cref='RelativeSize'/> .
        /// </summary>
        public static RelativePoint operator -(RelativePoint pt, RelativeSize sz) => Subtract(pt, sz);

        /// <summary>
        /// Compares two <see cref='RelativePoint'/> objects. The result specifies whether the values of 
        /// the <see cref='RelativePoint.X'/> and <see cref='RelativePoint.Y'/> properties of the two <see cref='RelativePoint'/> objects are equal.
        /// </summary>
        public static bool operator ==(RelativePoint left, RelativePoint right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Compares two <see cref='RelativePoint'/> objects. The result specifies whether the values of
        /// the <see cref='RelativePoint.X'/> or <see cref='RelativePoint.Y'/> properties of the two <see cref='RelativePoint'/> objects are unequal.
        /// </summary>
        public static bool operator !=(RelativePoint left, RelativePoint right) => !(left == right);

        /// <summary>
        /// Translates a <see cref='RelativePoint'/> by a given <see cref='RelativeSize'/> .
        /// </summary>
        public static RelativePoint Add(RelativePoint pt, RelativeSize sz) => new RelativePoint(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Translates a <see cref='RelativePoint'/> by the negative of a given <see cref='RelativeSize'/> .
        /// </summary>
        public static RelativePoint Subtract(RelativePoint pt, RelativeSize sz) => new RelativePoint(pt.X - sz.Width, pt.Y - sz.Height);

        public override bool Equals(object obj) => obj is RelativePoint && Equals((RelativePoint)obj);

        public bool Equals(RelativePoint other) => this == other;

        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * X.GetHashCode() *
                    19 * Y.GetHashCode();
            }
        }

        public override string ToString() => $"{{X={x}, Y={y}}}";
    }
}