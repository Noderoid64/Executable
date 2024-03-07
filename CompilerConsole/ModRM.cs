using System;

namespace CompilerConsole
{
    public static class ModRM
    {
        // Mod/Opt/RM
        public static byte Code(byte first, byte second, byte mode = 0b00000011)
        {
            return (byte) (first | (second << 5) | mode);
        }
        
        public static byte GetReg16FromString(string token)
        {
            switch (token)
            {
                case "ax": return 0x00;
                case "cx": return 0x01;
                case "dx": return 0x02;
                case "bx": return 0x03;
                case "sp": return 0x04;
                case "bp": return 0x05;
                case "si": return 0x06;
                case "di": return 0x07;
                default: throw new InvalidOperationException();
            }
        }

        public static byte GetReg32FromString(string token)
        {
            switch (token)
            {
                case "eax": return 0x00;
                case "ecx": return 0x01;
                case "edx": return 0x02;
                case "ebx": return 0x03;
                case "esp": return 0x04;
                case "ebp": return 0x05;
                case "esi": return 0x06;
                case "edi": return 0x07;
                default: throw new InvalidOperationException();
            }
        }
    }

    // namespace ModRmRegs
    // {
    //     public enum Reg32
    //     {
    //         EAX = 0x00,
    //         ECX = 0x01,
    //         EDX = 0x02,
    //         EBX = 0x03,
    //         ESP = 0x04,
    //         EBP = 0x05,
    //         ESI = 0x06,
    //         EDI = 0x07
    //     }
    //
    //     public enum Reg16
    //     {
    //         AX = 0x00,
    //         CX = 0x01,
    //         DX = 0x02,
    //         BX = 0x03,
    //         SP = 0x04,
    //         BP = 0x05,
    //         SI = 0x06,
    //         DI = 0x07,
    //     }
    //
    //     public enum Reg8
    //     {
    //         AL = 0x00,
    //         CL = 0x01,
    //         DL = 0x02,
    //         BL = 0x03,
    //         AH = 0x04,
    //         CH = 0x05,
    //         DH = 0x06,
    //         BH = 0x07,
    //     }
    // }

    
}