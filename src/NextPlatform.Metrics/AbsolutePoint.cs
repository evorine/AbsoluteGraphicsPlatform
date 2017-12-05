// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// This code is taken from .NET Core library which is MIT licensed.
// See https://github.com/dotnet/corefx

using System;

namespace NextPlatform.Metrics
{
    /// <summary>
    ///    Represents an ordered pair of x and y coordinates that
    ///    define a point in a two-dimensional plane.
    /// </summary>
    [Serializable]
    public struct AbsolutePoint : IEquatable<AbsolutePoint>
    {
        /// <summary>
        ///    <para>
        ///       Creates a new instance of the <see cref='AbsolutePoint'/> class
        ///       with member data left uninitialized.
        ///    </para>
        /// </summary>
        public static readonly AbsolutePoint Empty = new AbsolutePoint();
        private float x; // Do not rename (binary serialization) 
        private float y; // Do not rename (binary serialization) 

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='AbsolutePoint'/> class
        ///       with the specified coordinates.
        ///    </para>
        /// </summary>
        public AbsolutePoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///    <para>
        ///       Gets a value indicating whether this <see cref='AbsolutePoint'/> is empty.
        ///    </para>
        /// </summary>
        public bool IsEmpty => x == 0f && y == 0f;

        /// <summary>
        ///    <para>
        ///       Gets the x-coordinate of this <see cref='AbsolutePoint'/>.
        ///    </para>
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets the y-coordinate of this <see cref='AbsolutePoint'/>.
        ///    </para>
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='AbsolutePoint'/> by a given <see cref='AbsoluteSize'/> .
        ///    </para>
        /// </summary>
        public static AbsolutePoint operator +(AbsolutePoint pt, AbsoluteSize sz) => Add(pt, sz);

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='AbsolutePoint'/> by the negative of a given <see cref='AbsoluteSize'/> .
        ///    </para>
        /// </summary>
        public static AbsolutePoint operator -(AbsolutePoint pt, AbsoluteSize sz) => Subtract(pt, sz);

        /// <summary>
        ///    <para>
        ///       Compares two <see cref='AbsolutePoint'/> objects. The result specifies
        ///       whether the values of the <see cref='AbsolutePoint.X'/> and <see cref='AbsolutePoint.Y'/> properties of the two <see cref='AbsolutePoint'/>
        ///       objects are equal.
        ///    </para>
        /// </summary>
        public static bool operator ==(AbsolutePoint left, AbsolutePoint right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        ///    <para>
        ///       Compares two <see cref='AbsolutePoint'/> objects. The result specifies whether the values
        ///       of the <see cref='AbsolutePoint.X'/> or <see cref='AbsolutePoint.Y'/> properties of the two
        ///    <see cref='AbsolutePoint'/> 
        ///    objects are unequal.
        /// </para>
        /// </summary>
        public static bool operator !=(AbsolutePoint left, AbsolutePoint right) => !(left == right);

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='AbsolutePoint'/> by a given <see cref='AbsoluteSize'/> .
        ///    </para>
        /// </summary>
        public static AbsolutePoint Add(AbsolutePoint pt, AbsoluteSize sz) => new AbsolutePoint(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='AbsolutePoint'/> by the negative of a given <see cref='AbsoluteSize'/> .
        ///    </para>
        /// </summary>
        public static AbsolutePoint Subtract(AbsolutePoint pt, AbsoluteSize sz) => new AbsolutePoint(pt.X - sz.Width, pt.Y - sz.Height);

        public override bool Equals(object obj) => obj is AbsolutePoint && Equals((AbsolutePoint)obj);

        public bool Equals(AbsolutePoint other) => this == other;

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

        public override string ToString() => "{X=" + x.ToString() + ", Y=" + y.ToString() + "}";
    }
}