using System;
using System.Diagnostics;

namespace CompilerConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            var compiler = new CompilerV2.CompilerV2();
            var tokenizer = new Tokenizer();

            // foreach (var VARIABLE in tokenizer.GetTokensAsEnumerable("C:\\Users\\Mykhailo_Kryhin\\Desktop\\test.asm"))
            // {
            //     Console.WriteLine(VARIABLE);
            // }

            byte[] program = null;
            try
            {
                program =
                    compiler.Compile(tokenizer.GetTokensAsEnumerable("C:\\Users\\Mykhailo_Kryhin\\Desktop\\test.asm"));
            }
            catch (InvalidOperationException exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Compilation error on the line " + tokenizer.Line + ", position " + tokenizer.Position + ". Error: " + exception.Message);
                Console.ResetColor();
            }

            

            sw.Stop();
            Console.WriteLine("Compiled in " + sw.ElapsedMilliseconds);

            foreach (var b in program)
            {
                Console.Write(b + " ");
            }
        }
    }
}