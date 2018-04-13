// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ElementTree : IElementTree
    {
        private readonly IElementCollection elementCollection;

        public ElementTree(IComponent owner)
        {
            Owner = owner;
            elementCollection = new ManagedElementCollection(owner);
        }


        /// <summary>
        /// Gets the instance of the owner component.
        /// </summary>
        public IComponent Owner { get; }

        /// <summary>
        /// Gets the children elements
        /// </summary>
        public IElementCollection Children => elementCollection;

        #warning Fix here. Implement a better way to return placeholders!
        /// <summary>
        /// Gets all placeholders owned by this <see cref="IElementTree"/>
        /// </summary>
        public IElement[] PlaceholderElements => NavigateAllElementsRecursively(this).Where(x => x is ComponentPlaceholderComponent).ToArray();

        /// <summary>
        /// Finds and returns all child components recursively.
        /// </summary>
        public IEnumerable<IElement> GetAllElements() => NavigateAllElementsRecursively(this);


        /// <summary>
        /// Navigates and returns all member elements recursively.
        /// </summary>
        public static IEnumerable<IElement> NavigateAllElementsRecursively(IElementTree elementTree) => NavigateAllElementsRecursively(elementTree.Owner);

        /// <summary>
        /// Navigates and returns all children elements recursively including itself.
        /// </summary>
        public static IEnumerable<IElement> NavigateAllElementsRecursively(IElement element)
        {
            yield return element;

            foreach (var child in element.Children)
                foreach (var _child in NavigateAllElementsRecursively(child))
                    yield return _child;
        }

        /// <summary>
        /// Navigates and returns all children elements recursively.
        /// </summary>
        public static IEnumerable<IElement> NavigateAllChildrenRecursively(IElement element)
        {
            foreach (var child in element.Children)
                foreach (var _child in NavigateAllElementsRecursively(child))
                    yield return _child;
        }
    }
}
