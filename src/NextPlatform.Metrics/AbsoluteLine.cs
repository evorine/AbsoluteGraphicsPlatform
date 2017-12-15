// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics.Contracts;

namespace NextPlatform.Metrics
{
    /// <summary>
    ///     Stores the coordinates of a line.
    /// </summary>
    [Serializable]
    public struct AbsoluteLine : IEquatable<AbsoluteLine>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteLine'/>
        ///    class.
        /// </summary>
        public static readonly AbsoluteLine Empty = new AbsoluteLine();

        private float x1;
        private float y1;
        private float x2;
        private float y2;

        /// <summary>
        ///     Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteLine'/>.
        /// </summary>
        public AbsoluteLine(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteLine'/>.
        /// </summary>
        public AbsoluteLine(AbsolutePoint point1, AbsolutePoint point2)
        {
            this.x1 = point1.X;
            this.y1 = point1.Y;
            this.x2 = point2.X;
            this.y2 = point2.Y;
        }

        /// <summary>
        ///     Gets or sets the coordinates of the first point of the line.
        /// </summary>
        public AbsolutePoint Point1
        {
            get { return new AbsolutePoint(X1, Y1); }
            set
            {
                X1 = value.X;
                Y1 = value.Y;
            }
        }

        /// <summary>
        ///    Gets or sets the coordinates of the second point of the line.
        /// </summary>
        public AbsolutePoint Point2
        {
            get { return new AbsolutePoint(X1, Y1); }
            set
            {
                X1 = value.X;
                Y1 = value.Y;
            }
        }

        /// <summary>
        ///     Gets the length of this <see cref='NextPlatform.Metrics.AbsoluteLine'/>.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)); }
        }

        /// <summary>
        ///     Gets or sets the x-coordinate of the first point of the line.
        /// </summary>
        public float X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        /// <summary>
        ///     Gets or sets the y-coordinate of the first point of the line.
        /// </summary>
        public float Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        ///     Gets or sets the x-coordinate of the second point of the line.
        /// </summary>
        public float X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        /// <summary>
        ///     Gets or sets the y-coordinate of the second point of the line.
        /// </summary>
        public float Y2
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        ///     Tests whether <paramref name="obj"/> is a <see cref='NextPlatform.Metrics.AbsoluteLine'/> with the same location and length of this <see cref='NextPlatform.Metrics.AbsoluteLine'/>.
        /// </summary>
        public override bool Equals(object obj) => obj is AbsoluteLine && Equals((AbsoluteLine)obj);

        public bool Equals(AbsoluteLine other) => this == other;

        /// <summary>
        ///     Tests whether two <see cref='NextPlatform.Metrics.AbsoluteLine'/> objects have equal location and length.
        /// </summary>
        public static bool operator ==(AbsoluteLine left, AbsoluteLine right) =>
            left.X1 == right.X1 && left.Y1 == right.Y1 && left.X2 == right.X2 && left.Y2 == right.Y2;

        /// <summary>
        ///     Tests whether two <see cref='NextPlatform.Metrics.AbsoluteLine'/> objects differ in location or length.
        /// </summary>
        public static bool operator !=(AbsoluteLine left, AbsoluteLine right) => !(left == right);

        /// <summary>
        ///    Gets the hash code for this <see cref='NextPlatform.Metrics.AbsoluteLine'/>.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    17 * X1.GetHashCode() *
                    17 * Y1.GetHashCode() *
                    17 * X2.GetHashCode() *
                    17 * Y2.GetHashCode();
            }
        }

        /// <summary>
        ///    Adjusts the location of this line by the specified amount.
        /// </summary>
        public void Offset(AbsolutePoint pos) => Offset(pos.X, pos.Y);

        /// <summary>
        ///    Adjusts the location of this line by the specified amount.
        /// </summary>
        public void Offset(float x, float y)
        {
            X1 += x;
            Y1 += y;
            X2 += x;
            Y2 += y;
        }

        /// <summary>
        ///    Converts this line to a human-readable string.
        /// </summary>
        public override string ToString() => $"{{X1={X1},Y1={Y1},X2={X2},Y2={Y2}}}";
    }
}