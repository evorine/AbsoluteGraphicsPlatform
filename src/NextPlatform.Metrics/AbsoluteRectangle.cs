// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

// This code is taken from .NET Core library which is under MIT licensed.
// See https://github.com/dotnet/corefx

using System;
using System.Diagnostics.Contracts;

namespace NextPlatform.Metrics
{
    /// <summary>
    ///    <para>
    ///       Stores the location and size of a rectangular region.
    ///    </para>
    /// </summary>
    [Serializable]
    public struct AbsoluteRectangle : IEquatable<AbsoluteRectangle>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///    class.
        /// </summary>
        public static readonly AbsoluteRectangle Empty = new AbsoluteRectangle();

        private float x; // Do not rename (binary serialization) 
        private float y; // Do not rename (binary serialization) 
        private float width; // Do not rename (binary serialization) 
        private float height; // Do not rename (binary serialization) 

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       class with the specified location and size.
        ///    </para>
        /// </summary>
        public AbsoluteRectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       class with the specified location
        ///       and size.
        ///    </para>
        /// </summary>
        public AbsoluteRectangle(AbsolutePoint location, AbsoluteSize size)
        {
            x = location.X;
            y = location.Y;
            width = size.Width;
            height = size.Height;
        }

        /// <summary>
        ///    <para>
        ///       Creates a new <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> with
        ///       the specified location and size.
        ///    </para>
        /// </summary>
        public static AbsoluteRectangle FromLTRB(float left, float top, float right, float bottom) =>
            new AbsoluteRectangle(left, top, right - left, bottom - top);

        /// <summary>
        ///    <para>
        ///       Gets or sets the coordinates of the upper-left corner of
        ///       the rectangular region represented by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public AbsolutePoint Location
        {
            get { return new AbsolutePoint(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the size of this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public AbsoluteSize Size
        {
            get { return new AbsoluteSize(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the x-coordinate of the
        ///       upper-left corner of the rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the y-coordinate of the
        ///       upper-left corner of the rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the width of the rectangular
        ///       region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the height of the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets the x-coordinate of the upper-left corner of the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> .
        ///    </para>
        /// </summary>
        public float Left => X;

        /// <summary>
        ///    <para>
        ///       Gets the y-coordinate of the upper-left corner of the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Top => Y;

        /// <summary>
        ///    <para>
        ///       Gets the x-coordinate of the lower-right corner of the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Right => X + Width;

        /// <summary>
        ///    <para>
        ///       Gets the y-coordinate of the lower-right corner of the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public float Bottom => Y + Height;

        /// <summary>
        ///    <para>
        ///       Tests whether this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> has a <see cref='NextPlatform.Metrics.AbsoluteRectangle.Width'/> or a <see cref='NextPlatform.Metrics.AbsoluteRectangle.Height'/> of 0.
        ///    </para>
        /// </summary>
        public bool IsEmpty => (Width <= 0) || (Height <= 0);

        /// <summary>
        ///    <para>
        ///       Tests whether <paramref name="obj"/> is a <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> with the same location and size of this
        ///    <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        ///    </para>
        /// </summary>
        public override bool Equals(object obj) => obj is AbsoluteRectangle && Equals((AbsoluteRectangle)obj);

        public bool Equals(AbsoluteRectangle other) => this == other;

        /// <summary>
        ///    <para>
        ///       Tests whether two <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       objects have equal location and size.
        ///    </para>
        /// </summary>
        public static bool operator ==(AbsoluteRectangle left, AbsoluteRectangle right) =>
            left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        ///    <para>
        ///       Tests whether two <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       objects differ in location or size.
        ///    </para>
        /// </summary>
        public static bool operator !=(AbsoluteRectangle left, AbsoluteRectangle right) => !(left == right);

        /// <summary>
        ///    <para>
        ///       Determines if the specified point is contained within the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> .
        ///    </para>
        /// </summary>
        [Pure]
        public bool Contains(float x, float y) => X <= x && x < X + Width && Y <= y && y < Y + Height;

        /// <summary>
        ///    <para>
        ///       Determines if the specified point is contained within the
        ///       rectangular region defined by this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> .
        ///    </para>
        /// </summary>
        [Pure]
        public bool Contains(AbsolutePoint pt) => Contains(pt.X, pt.Y);

        /// <summary>
        ///    <para>
        ///       Determines if the rectangular region represented by
        ///    <paramref name="rect"/> is entirely contained within the rectangular region represented by 
        ///       this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> .
        ///    </para>
        /// </summary>
        [Pure]
        public bool Contains(AbsoluteRectangle rect) =>
            (X <= rect.X) && (rect.X + rect.Width <= X + Width) && (Y <= rect.Y) && (rect.Y + rect.Height <= Y + Height);

        /// <summary>
        ///    Gets the hash code for this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
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
        ///    <para>
        ///       Inflates this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       by the specified amount.
        ///    </para>
        /// </summary>
        public void Inflate(float x, float y)
        {
            X -= x;
            Y -= y;
            Width += 2 * x;
            Height += 2 * y;
        }

        /// <summary>
        ///    Inflates this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> by the specified amount.
        /// </summary>
        public void Inflate(AbsoluteSize size) => Inflate(size.Width, size.Height);

        /// <summary>
        ///    <para>
        ///       Creates a <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>
        ///       that is inflated by the specified amount.
        ///    </para>
        /// </summary>
        public static AbsoluteRectangle Inflate(AbsoluteRectangle rect, float x, float y)
        {
            AbsoluteRectangle r = rect;
            r.Inflate(x, y);
            return r;
        }

        /// <summary> Creates a Rectangle that represents the intersection between this Rectangle and rect.
        /// </summary>
        public void Intersect(AbsoluteRectangle rect)
        {
            AbsoluteRectangle result = Intersect(rect, this);

            X = result.X;
            Y = result.Y;
            Width = result.Width;
            Height = result.Height;
        }

        /// <summary>
        ///    Creates a rectangle that represents the intersection between a and
        ///    b. If there is no intersection, null is returned.
        /// </summary>
        [Pure]
        public static AbsoluteRectangle Intersect(AbsoluteRectangle a, AbsoluteRectangle b)
        {
            float x1 = Math.Max(a.X, b.X);
            float x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            float y1 = Math.Max(a.Y, b.Y);
            float y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
            {
                return new AbsoluteRectangle(x1, y1, x2 - x1, y2 - y1);
            }

            return Empty;
        }

        /// <summary>
        ///    Determines if this rectangle intersects with rect.
        /// </summary>
        [Pure]
        public bool IntersectsWith(AbsoluteRectangle rect) =>
            (rect.X < X + Width) && (X < rect.X + rect.Width) && (rect.Y < Y + Height) && (Y < rect.Y + rect.Height);

        /// <summary>
        ///    Creates a rectangle that represents the union between a and
        ///    b.
        /// </summary>
        [Pure]
        public static AbsoluteRectangle Union(AbsoluteRectangle a, AbsoluteRectangle b)
        {
            float x1 = Math.Min(a.X, b.X);
            float x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            float y1 = Math.Min(a.Y, b.Y);
            float y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new AbsoluteRectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        ///    Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(AbsolutePoint pos) => Offset(pos.X, pos.Y);

        /// <summary>
        ///    Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(float x, float y)
        {
            X += x;
            Y += y;
        }

        /// <summary>
        ///    Converts the specified <see cref='System.Drawing.Rectangle'/> to a
        /// <see cref='NextPlatform.Metrics.AbsoluteRectangle'/>.
        /// </summary>
        public static implicit operator AbsoluteRectangle(System.Drawing.Rectangle r) => new AbsoluteRectangle(r.X, r.Y, r.Width, r.Height);

        /// <summary>
        ///    Converts the <see cref='NextPlatform.Metrics.AbsoluteRectangle.Location'/> and <see cref='NextPlatform.Metrics.AbsoluteRectangle.Size'/> of this <see cref='NextPlatform.Metrics.AbsoluteRectangle'/> to a
        ///    human-readable string.
        /// </summary>
        public override string ToString() =>
            "{X=" + X.ToString() + ",Y=" + Y.ToString() +
            ",Width=" + Width.ToString() + ",Height=" + Height.ToString() + "}";
    }
}