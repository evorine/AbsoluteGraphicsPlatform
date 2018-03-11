// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.AGPx.Instructions;
using System.Collections;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class DssInstructions : ICollection<IInstruction>
    {
        readonly IList<IInstruction> instructions;

        public DssInstructions()
        {
            instructions = new List<IInstruction>();
        }


        public int Count => instructions.Count;

        public void Add(IInstruction instruction) => instructions.Add(instruction);
        public bool Remove(IInstruction instruction) => instructions.Remove(instruction);
        public void Clear() => instructions.Clear();
        bool ICollection<IInstruction>.Contains(IInstruction instruction) => instructions.Contains(instruction);

        
        public IEnumerator<IInstruction> GetEnumerator() => instructions.GetEnumerator();

        bool ICollection<IInstruction>.IsReadOnly => false;
        void ICollection<IInstruction>.CopyTo(IInstruction[] array, int arrayIndex) => instructions.CopyTo(array, arrayIndex);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)instructions).GetEnumerator();
    }
}
