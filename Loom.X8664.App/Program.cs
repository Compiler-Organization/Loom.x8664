using Loom.x8664;
using Loom.x8664.Objects;
using System.Runtime.InteropServices;
using System;

namespace Loom.X8664.App
{
    delegate int BinaryOp(int a, int b);
    internal class Program
    {
        [DllImport("kernel32")]
        static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        static void Main(string[] args)
        {
            List<Instruction> instructions = new List<Instruction>()
            {
                new Instruction
                {
                    Mnemonics = new List<Mnemonics>() { Mnemonics.Add_rm163264_r163264 },
                    Operands = new List<byte>() 
                    {
                        (byte)((byte)InstructionSpec.Modifiers.DisplacementOnly
                        + InstructionSpec.MoveRegisterLeft((byte)InstructionSpec.Registers.Cx)
                        + (byte)InstructionSpec.Registers.Dx)
                    }
                },
                new Instruction
                {
                    Mnemonics = new List<Mnemonics>() { Mnemonics.Mov_rm163264_r163264 },
                    Operands = new List<byte>()
                    {
                        (byte)((byte)InstructionSpec.Modifiers.DisplacementOnly
                        + InstructionSpec.MoveRegisterLeft((byte)InstructionSpec.Registers.Dx)
                        + (byte)InstructionSpec.Registers.Ax)
                    }
                },
                new Instruction
                {
                    Mnemonics = new List<Mnemonics>() { Mnemonics.Retn },
                    Operands = new List<byte>()
                }
            };

            Emitter emitter = new Emitter();
            byte[] bytecode = emitter.EmitAll(instructions);

            IntPtr mem = Marshal.AllocHGlobal(bytecode.Length);
            Marshal.Copy(bytecode, 0, mem, bytecode.Length);
            VirtualProtect(mem, (UIntPtr)bytecode.Length, 0x40 /*PAGE_EXECUTE_READWRITE*/, out uint old);
            var fn = (BinaryOp)Marshal.GetDelegateForFunctionPointer(mem, typeof(BinaryOp));

            Console.WriteLine(fn(2, 3));
            Console.WriteLine(mem.ToString());
            Marshal.FreeHGlobal(mem);

            Console.WriteLine(BitConverter.ToString(bytecode));
        }
    }
}