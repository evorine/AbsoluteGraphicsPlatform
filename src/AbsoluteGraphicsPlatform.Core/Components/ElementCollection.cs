// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Humanizer;

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

        public virtual int Count => elementList.Count;

        public virtual void Add(IElement element)
        {
            elementList.Add(element);
        }

        public virtual void Insert(int index, IElement element)
        {
            elementList.Insert(index, element);
        }

        public virtual void Clear()
        {
            foreach (var element in elementList)
                element.Parent = null;
            elementList.Clear();
        }

        public virtual bool Contains(IElement element) => elementList.Contains(element);

        public virtual bool Remove(IElement element) => elementList.Remove(element);

        public IEnumerator<IElement> GetEnumerator() => elementList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)elementList).GetEnumerator();

        public override string ToString() => $"Collection: {"element".ToQuantity(Count)}";
    }
}
