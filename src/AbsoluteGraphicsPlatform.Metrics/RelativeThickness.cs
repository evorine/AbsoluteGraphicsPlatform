
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /// <summary>
    /// Stores the thickness of a boxes borders.
    /// </summary>
    [Serializable]
    public struct RelativeThickness : IEquatable<RelativeThickness>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeThickness'/> class.
        /// </summary>
        public static readonly RelativeThickness Empty = new RelativeThickness();

        private RelativeLength top;
        private RelativeLength right;
        private RelativeLength bottom;
        private RelativeLength left;

        /// <summary>
        /// Initializes a new instance of the <see cref='RelativeThickness'/> class.
        /// </summary>
        public RelativeThickness(RelativeLength top, RelativeLength right, RelativeLength bottom, RelativeLength left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        /// <summary>
        /// Gets or sets the height of the top border.
        /// </summary>
        public RelativeLength Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>
        /// Gets or sets the width of the right border.
        /// </summary>
        public RelativeLength Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// Gets or sets the height of the bottom border.
        /// </summary>
        public RelativeLength Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        /// <summary>
        /// Gets or sets the width of the left border.
        /// </summary>
        public RelativeLength Left
        {
            get { return left; }
            set { left = value; }
        }


        /// <summary>
        /// Checks whether this <see cref='RelativeThickness'/> has any value.
        /// </summary>
        public bool IsEmpty => (Top != RelativeLength.Zero) && (Right != RelativeLength.Zero) && (Bottom != RelativeLength.Zero) && (Left != RelativeLength.Zero);

        /// <summary>
        /// Tests whether <paramref name="obj"/> is a <see cref='RelativeThickness'/> with the same border sizes of this <see cref='RelativeThickness'/>.
        /// </summary>
        public override bool Equals(object obj) => obj is RelativeThickness && Equals((RelativeThickness)obj);

        public bool Equals(RelativeThickness other) => this == other;

        /// <summary>
        /// Tests whether two <see cref='RelativeThickness'/> objects have border sizes.
        /// </summary>
        public static bool operator ==(RelativeThickness left, RelativeThickness right) =>
            left.Top == right.Top && left.Right == right.Right && left.Bottom == right.Bottom && left.Left == right.Left;

        /// <summary>
        /// Tests whether two <see cref='RelativeThickness'/> objects differ in border sizes.
        /// </summary>
        public static bool operator !=(RelativeThickness left, RelativeThickness right) => !(left == right);

        /// <summary>
        /// Gets the hash code for this <see cref='RelativeThickness'/>.
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
        /// Inflates this <see cref='RelativeThickness'/> by the specified amount.
        /// </summary>
        public void Inflate(RelativeLength value)
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