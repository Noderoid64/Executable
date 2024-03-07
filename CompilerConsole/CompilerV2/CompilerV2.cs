using System;
using System.Collections.Generic;

namespace CompilerConsole.CompilerV2
{
    public class CompilerV2
    {
        private const byte prefixFor16bitCommands = 0x66;
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
                    case "add": HandleAdd(enumerator); break;
                    default: throw new InvalidOperationException("invalid token '" + token + "'");
                }
            }
            enumerator.Dispose();
            
            return _compiled.ToArray();
        }

        private void HandleAdd(IEnumerator<string> tokens)
        {
            tokens.MoveNext();
            string opt1 = tokens.Current.ToLower();
            tokens.MoveNext();
            string opt2 = tokens.Current.ToLower();
            if (opt1.Equals("ax") && opt2.StartsWith("0x") && opt2.Length == 6)
            {
                _compiled.Add(prefixFor16bitCommands);
                _compiled.Add(0x05);
                foreach (var b in Helper.ConvertHexStringTo2ByteArray(opt2))
                {
                    _compiled.Add(b);
                }

                return;
            }
            if (opt1.Equals("eax") && opt2.StartsWith("0x") && opt2.Length == 10)
            {
                _compiled.Add(0x05);
                foreach (var b in Helper.ConvertHexStringTo4ByteArray(opt2))
                {
                    _compiled.Add(b);
                }

                return;
            } else if (Reg32.Contains(opt1))
            {
                if (Reg32.Contains(opt2))
                {
                    _compiled.Add(0x01); // optCode
                    _compiled.Add(ModRM.Code(ModRM.GetReg32FromString(opt1), ModRM.GetReg32FromString(opt2)));
                    return;
                } else if (opt2.StartsWith("0x") && opt2.Length == 10)
                {
                    _compiled.Add(0x83);
                    _compiled.Add(ModRM.Code(ModRM.GetReg32FromString(opt1), 0x00));
                    foreach (var b in Helper.ConvertHexStringTo4ByteArray(opt2))
                    {
                        _compiled.Add(b);
                    }

                    return;
                }
            } else if (Reg16.Contains(opt1))
            {
                if (Reg16.Contains(opt2))
                {
                    _compiled.Add(prefixFor16bitCommands);
                    _compiled.Add(0x01); // optCode
                    _compiled.Add(ModRM.Code(ModRM.GetReg16FromString(opt1), ModRM.GetReg16FromString(opt2)));
                    return;
                } else if (opt2.StartsWith("0x") && opt2.Length == 6)
                {
                    _compiled.Add(0x83);
                    _compiled.Add(ModRM.Code(ModRM.GetReg16FromString(opt1), 0x00));
                    foreach (var b in Helper.ConvertHexStringTo2ByteArray(opt2))
                    {
                        _compiled.Add(b);
                    }

                    return;
                }
            }

            throw new InvalidOperationException("unexpected add command argument");
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
                    _compiled.Add(0x89); // optCode
                    _compiled.Add(ModRM.Code(ModRM.GetReg32FromString(opt1), ModRM.GetReg32FromString(opt2)));
                    return;
                }
            } else if (Reg16.Contains(opt1))
            {
                tokens.MoveNext();
                string opt2 = tokens.Current;
                if (Reg16.Contains(opt2))
                {
                    _compiled.Add(prefixFor16bitCommands);
                    _compiled.Add(0x89); // optCode
                    _compiled.Add(ModRM.Code(ModRM.GetReg16FromString(opt1), ModRM.GetReg16FromString(opt2)));
                    return;
                }
            }

            throw new InvalidOperationException("unexpected mov command argument");
        }
    }
}