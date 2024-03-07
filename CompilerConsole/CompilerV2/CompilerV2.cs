using System;
using System.Collections.Generic;

namespace CompilerConsole.CompilerV2
{
    public class CompilerV2
    {
        private List<byte> _compiled = new List<byte>(256);
        
        public byte[] Compile(IEnumerable<string> tokens)
        {
            var enumerator = tokens.GetEnumerator();
            string token;
            while (enumerator.MoveNext())
            {
                token = enumerator.Current.ToLower();
                switch (token)
                {
                    case "mov": HandleMov(enumerator); break;
                    default: throw new InvalidOperationException("invalid token '" + token + "'");
                }
            }
            enumerator.Dispose();
            
            return _compiled.ToArray();
        }

        private void HandleMov(IEnumerator<string> tokens)
        {
            tokens.MoveNext();
            string opt1 = tokens.Current;
            if (Reg32.Contains(opt1))
            {
                tokens.MoveNext();
                string opt2 = tokens.Current;
                if (Reg32.Contains(opt2))
                {
                    _compiled.Add(0x89);
                    _compiled.Add(ModRM.Code32(ModRM.GetReg32FromString(opt1), ModRM.GetReg32FromString(opt2)));
                    return;
                }
            }

            throw new InvalidOperationException("unexpected mov command argument");
        }
    }
}