﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /// <summary>
    /// Stores the thickness of a boxes borders.
    /// </summary>
    [Serializable]
    public struct AbsoluteThickness : IEquatable<AbsoluteThickness>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> class.
        /// </summary>
        public static readonly AbsoluteThickness Empty = new AbsoluteThickness();

        private float top;
        private float right;
        private float bottom;
        private float left;

        /// <summary>
        /// Initializes a new instance of the <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> class.
        /// </summary>
        public AbsoluteThickness(float top, float right, float bottom, float left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        /// <summary>
        /// Gets or sets the height of the top border.
        /// </summary>
        public float Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>
        /// Gets or sets the width of the right border.
        /// </summary>
        public float Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the height of the bottom border.
        ///    </para>
        /// </summary>
        public float Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        /// <summary>
        /// Gets or sets the width of the left border.
        /// </summary>
        public float Left
        {
            get { return left; }
            set { left = value; }
        }


        /// <summary>
        /// Checks whether this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> has any value.
        /// </summary>
        public bool IsEmpty => (Top != 0) && (Right != 0) && (Bottom != 0) && (Left != 0);

        /// <summary>
        /// Tests whether <paramref name="obj"/> is a <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> with the same border sizes of this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/>.
        /// </summary>
        public override bool Equals(object obj) => obj is AbsoluteThickness && Equals((AbsoluteThickness)obj);

        public bool Equals(AbsoluteThickness other) => this == other;

        /// <summary>
        /// Tests whether two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> objects have border sizes.
        /// </summary>
        public static bool operator ==(AbsoluteThickness left, AbsoluteThickness right) =>
            left.Top == right.Top && left.Right == right.Right && left.Bottom == right.Bottom && left.Left == right.Left;

        /// <summary>
        /// Tests whether two <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> objects differ in border sizes.
        /// </summary>
        public static bool operator !=(AbsoluteThickness left, AbsoluteThickness right) => !(left == right);

        /// <summary>
        /// Gets the hash code for this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/>.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * Top.GetHashCode() *
                    19 * Right.GetHashCode() *
                    19 * Bottom.GetHashCode() *
                    19 * Left.GetHashCode();
            }
        }

        /// <summary>
        /// Inflates this <see cref='AbsoluteGraphicsPlatform.Metrics.AbsoluteThickness'/> by the specified amount.
        /// </summary>
        public void Inflate(float value)
        {
            Top += value;
            Right += value;
            Bottom += value;
            Left += value;
        }

        /// <summary>
        /// Converts this to a human-readable string.
        /// </summary>
        public override string ToString() => $"{{Top={Top},Right={Right},Bottom={Bottom},Left={Left}}}";
    }
}