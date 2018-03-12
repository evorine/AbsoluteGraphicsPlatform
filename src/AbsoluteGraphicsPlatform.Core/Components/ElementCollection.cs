// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ElementCollection : IElementCollection
    {
        protected readonly IList<IElement> elementList;

        public ElementCollection()
        {
            elementList = new List<IElement>();
        }

        public IElement this[int index] => elementList[index];

        public int Count => elementList.Count;

        public void Add(IElement element)
        {
            elementList.Add(element);
            //element.Parent = element;
        }

        public void Insert(int index, IElement element)
        {
            elementList.Insert(index, element);
            //element.Parent = element;
        }

        public void Clear()
        {
            foreach (var element in elementList)
                element.Parent = null;
            elementList.Clear();
        }

        public bool Contains(IElement item) => elementList.Contains(item);

        public bool Remove(IElement item)
        {
            if (elementList.Remove(item))
            {
                item.Parent = null;
                return true;
            }
            else return false;
        }

        public IEnumerator<IElement> GetEnumerator() => elementList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)elementList).GetEnumerator();

        public override string ToString() => $"ElementCollection: {Count} item{(Count > 1 ? "s" : "")}";
    }
}
