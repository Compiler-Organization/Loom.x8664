using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loom.x8664.Objects
{
    public struct InstructionSpec
    {
        public byte MoveRegisterRight(byte register) => (byte)(register >> 3);
        public static byte MoveRegisterLeft(byte register) => (byte)(register << 3);

        public enum Modifiers : byte         
        {
            /// <summary>
            /// Register direct addressing mode
            /// </summary>
            Register = 0b00_000_000,
            /// <summary>
            /// Register indirect addressing mode
            /// </summary>
            Indirect = 0b01_000_000,
            /// <summary>
            /// Base + index addressing mode
            /// </summary>
            BaseIndex = 0b10_000_000,
            /// <summary>
            /// Displacement only addressing mode
            /// </summary>
            DisplacementOnly = 0b11_000_000
        }

        /// <summary>
        /// x86 / x64 registers
        /// </summary>
        public enum Registers : byte
        {
            /// <summary>
            /// AL/AX/EAX/RAX/ST0/MM0/XMM0
            /// </summary>
            Ax = 0b000,

            /// <summary>
            /// CL/CX/ECX/RCX/ST1/MM1/XMM1
            /// </summary>
            Cx = 0b001,

            /// <summary>
            /// DL/DX/EDX/RDX/ST2/MM2/XMM2
            /// </summary>
            Dx = 0b010,

            /// <summary>
            /// BL/BX/EBX/RBX/ST3/MM3/XMM3	
            /// </summary>
            Bx = 0b011,

            /// <summary>
            /// AH/SP/ESP/RSP/ST4/MM4/XMM4
            /// </summary>
            Sp = 0b100,

            /// <summary>
            /// CH/BP/EBP/RBP/ST5/MM5/XMM5
            /// </summary>
            Bp = 0b101,

            /// <summary>
            /// DH/SI/ESI/RSI/ST6/MM6/XMM6
            /// </summary>
            Si = 0b110,

            /// <summary>
            /// BH/DI/EDI/RDI/ST7/MM7/XMM7
            /// </summary>
            Di = 0b111
        }
    }
}
