using AbsoluteGraphicsPlatform.Abstractions.Styling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Styling
{
    /// <summary>
    /// Represents a styles collection.
    /// </summary>
    public class StyleCollection : ICollection<IStyle>
    {
        private readonly List<IStyle> collection;

        public StyleCollection()
        {
            collection = new List<IStyle>();
        }

        /// <summary>
        /// Adds a style to the collection.
        /// </summary>
        /// <param name="style">The new style to add.</param>
        public void Add(IStyle style) => collection.Add(style);

        /// <summary>
        /// Removes the specified style from the collection.
        /// </summary>
        /// <param name="style">The style to remove.</param>
        /// <returns></returns>
        public bool Remove(IStyle style) => collection.Remove(style);

        /// <summary>
        /// Removes all styles from the collection.
        /// </summary>
        public void Clear() => collection.Clear();

        /// <summary>
        /// Determines whether the collection contains the specified style.
        /// </summary>
        /// <param name="style">The style to look for.</param>
        public bool Contains(IStyle style) => collection.Contains(style);

        /// <summary>
        /// Gets the number of styles.
        /// </summary>
        public int Count => collection.Count;

        bool ICollection<IStyle>.IsReadOnly => false;

        void ICollection<IStyle>.CopyTo(IStyle[] styles, int index) => collection.CopyTo(styles, index);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<IStyle> GetEnumerator() => collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)collection).GetEnumerator();
    }
}
