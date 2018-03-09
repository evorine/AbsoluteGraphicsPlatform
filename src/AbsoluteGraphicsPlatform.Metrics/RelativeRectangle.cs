// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

// This file is forked from .NET Core library which is under MIT licensed.
// See https://github.com/dotnet/corefx

using System;
using System.Diagnostics.Contracts;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /// <summary>
    /// Stores the location and size of a rectangular region.
    /// </summary>
    [Serializable]
    public struct RelativeRectangle : IEquatable<RelativeRectangle>
    {
        public static readonly RelativeRectangle Empty = new RelativeRectangle();

        private RelativeLength x;
        private RelativeLength y;
        private RelativeLength width;
        private RelativeLength height;

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeRectangle'/> class with the specified location and size.
        /// </summary>
        public RelativeRectangle(RelativeLength x, RelativeLength y, RelativeLength width, RelativeLength height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeRectangle'/> class with the specified location and size.
        /// </summary>
        public RelativeRectangle(RelativePoint location, RelativeSize size)
        {
            x = location.X;
            y = location.Y;
            width = size.Width;
            height = size.Height;
        }

        /// <summary>
        /// Creates a new <see cref='RelativeRectangle'/> with the specified location and size.
        /// </summary>
        public static RelativeRectangle FromLTRB(RelativeLength left, RelativeLength top, RelativeLength right, RelativeLength bottom) =>
            new RelativeRectangle(left, top, right - left, bottom - top);

        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the rectangular region represented by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativePoint Location
        {
            get { return new RelativePoint(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the size of this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeSize Size
        {
            get { return new RelativeSize(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the height of the
        ///       rectangular region defined by this <see cref='RelativeRectangle'/>.
        ///    </para>
        /// </summary>
        public RelativeLength Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Gets the x-coordinate of the upper-left corner of the rectangular region defined by this <see cref='RelativeRectangle'/> .
        /// </summary>
        public RelativeLength Left => X;

        /// <summary>
        /// Gets the y-coordinate of the upper-left corner of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength Top => Y;

        /// <summary>
        /// Gets the x-coordinate of the lower-right corner of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength Right => X + Width;

        /// <summary>
        /// Gets the y-coordinate of the lower-right corner of the rectangular region defined by this <see cref='RelativeRectangle'/>.
        /// </summary>
        public RelativeLength Bottom => Y + Height;

        /// <summary>
        /// Tests whether this <see cref='RelativeRectangle'/> has a <see cref='RelativeRectangle.Width'/> or a <see cref='RelativeRectangle.Height'/> of 0.
        /// </summary>
        public bool IsEmpty => (Width == RelativeLength.Zero) || (Height == RelativeLength.Zero);

        /// <summary>
        /// Tests whether <paramref name="obj"/> is a <see cref='RelativeRectangle'/> with the same location and size of this <see cref='RelativeRectangle'/>.
        /// </summary>
        public override bool Equals(object obj) => obj is RelativeRectangle && Equals((RelativeRectangle)obj);

        public bool Equals(RelativeRectangle other) => this == other;

        /// <summary>
        /// Tests whether two <see cref='RelativeRectangle'/> objects have equal location and size.
        /// </summary>
        public static bool operator ==(RelativeRectangle left, RelativeRectangle right) =>
            left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// Tests whether two <see cref='RelativeRectangle'/> objects differ in location or size.
        /// </summary>
        public static bool operator !=(RelativeRectangle left, RelativeRectangle right) => !(left == right);

        /// <summary>
        /// Gets the hash code for this <see cref='RelativeRectangle'/>.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * X.GetHashCode() *
                    19 * Y.GetHashCode() *
                    19 * Width.GetHashCode() *
                    19 * Height.GetHashCode();
            }
        }

        /// <summary>
        /// Inflates this <see cref='RelativeRectangle'/> by the specified amount.
        /// </summary>
        public void Inflate(RelativeLength x, RelativeLength y)
        {
            X -= x;
            Y -= y;
            Width += 2 * x;
            Height += 2 * y;
        }

        /// <summary>
        /// Inflates this <see cref='RelativeRectangle'/> by the specified amount.
        /// </summary>
        public void Inflate(RelativeSize size) => Inflate(size.Width, size.Height);

        /// <summary>
        /// Creates a <see cref='RelativeRectangle'/> that is inflated by the specified amount.
        /// </summary>
        public static RelativeRectangle Inflate(RelativeRectangle rect, RelativeLength x, RelativeLength y)
        {
            RelativeRectangle r = rect;
            r.Inflate(x, y);
            return r;
        }

        /// <summary>
        /// Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(RelativePoint pos) => Offset(pos.X, pos.Y);

        /// <summary>
        /// Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(RelativeLength x, RelativeLength y)
        {
            X += x;
            Y += y;
        }

        /// <summary>
        /// Converts the specified <see cref='System.Drawing.Rectangle'/> to a <see cref='RelativeRectangle'/>.
        /// </summary>
        public static implicit operator RelativeRectangle(System.Drawing.Rectangle r) => new RelativeRectangle(r.X, r.Y, r.Width, r.Height);

        /// <summary>
        /// Converts the <see cref='RelativeRectangle.Location'/> and <see cref='RelativeRectangle.Size'/> of this <see cref='RelativeRectangle'/> to a human-readable string.
        /// </summary>
        public override string ToString() => $"{{X={X}, Y={Y}, Width={Width}, Height={Height}}}";
    }
}