using Loom.x8664.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loom.x8664
{
    public class Emitter
    {
        public byte[] EmitAll(List<Instruction> instructions)
        {
            List<byte> builder = new List<byte>();

            foreach(Instruction instruction in instructions)
            {
                foreach(Mnemonics mnemonic in instruction.Mnemonics)
                {
                    builder.Add((byte)mnemonic);
                }
                foreach(byte operand in instruction.Operands)
                {
                    builder.Add(operand);
                }
            }

            return builder.ToArray();
        }
    }
}
