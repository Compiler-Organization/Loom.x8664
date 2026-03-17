using System;
using System.Collections.Generic;
using System.Text;

namespace Loom.x8664.Objects
{
    public class Instruction
    {

        public List<Mnemonics> Mnemonics { get; set; } = new List<Mnemonics>();

        public List<byte> Operands { get; set; } = new List<byte>();
    }
}
