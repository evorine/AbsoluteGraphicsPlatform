// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ManagedElementCollection : ElementCollection
    {
        readonly IElement ownerElement;

        public ManagedElementCollection(IElement ownerElement)
        {
            this.ownerElement = ownerElement;
        }

        public override void Add(IElement element)
        {
            base.Add(element);
            element.Parent = ownerElement;
        }

        public override void Insert(int index, IElement element)
        {
            base.Insert(index, element);
            element.Parent = ownerElement;
        }

        public override bool Remove(IElement element)
        {
            if (base.Remove(element))
            {
                element.Parent = null;
                return true;
            }
            return false;
        }

        public override void Clear()
        {
            foreach (var element in elementList)
                element.Parent = null;
            base.Clear();
        }
    }
}
