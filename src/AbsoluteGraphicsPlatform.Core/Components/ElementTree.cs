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
        private readonly ElementCollection elementCollection;

        public ElementTree(IComponent owner)
        {
            elementCollection = new ElementCollection();
            Owner = owner;
        }


        /// <summary>
        /// Gets the instance of the owner component.
        /// </summary>
        public IComponent Owner { get; }

        public IElementCollection Children => elementCollection;

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
