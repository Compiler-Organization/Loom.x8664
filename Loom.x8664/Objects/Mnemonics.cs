using System;
using System.Collections.Generic;
using System.Text;

namespace Loom.x8664.Objects
{
    public enum Mnemonics
    {
        Add_rm8_R8 = 0x00,
        Add_rm163264_r163264 = 0x01,
        Add_r8_rm8 = 0x02,
        Add_r163264_rm163264 = 0x03,
        Add_Al_imm8 = 0x04,
        Add_rAX_imm1632 = 0x05,

        // ...

        Mov_rm163264_r163264 = 0x89,

        // ...

        Retn = 0xC3,
    }
}
