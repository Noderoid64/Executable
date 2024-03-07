using System.Collections.Generic;

namespace CompilerConsole
{
    public static class Reg32
    {
        public static readonly HashSet<string> Set = new HashSet<string>()
        {
            "eax",
            "ecx",
            "edx",
            "ebx",
            "esp",
            "ebp",
            "esi",
            "edi"
        };

        public static bool Contains(string token)
        {
            return Set.Contains(token);
        }
    }

    public static class Reg16
    {
        public static readonly HashSet<string> Set = new HashSet<string>()
        {
            "ax",
            "cx",
            "dx",
            "bx",
            "sp",
            "bp",
            "si",
            "di"
        };
            
        public static bool Contains(string token)
        {
            return Set.Contains(token);
        }
    }
}