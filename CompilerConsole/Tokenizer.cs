using System.Collections.Generic;
using System.IO;

namespace CompilerConsole
{
    
    
    public class Tokenizer
    {
        public int Line { get; private set; }
        public int Position { get; private set; }

        public IEnumerable<string> GetTokensAsEnumerable(string fileName, int bufferSize = 256)
        {
            char[] buffer = new char[bufferSize];
            using (var sr = new StreamReader(fileName))
            {
                int readChars = 0;
                int stringStart = 0;
                do
                {
                    readChars = sr.ReadBlock(buffer, 0, bufferSize);
                    for (int i = 0; i < readChars; i++)
                    {
                        var item = buffer[i];
                        if (item == '\r' || item == '\n')
                        {
                            Position = 0;
                            Line++;
                            if (i != stringStart)
                                yield return new string(buffer, stringStart, i - stringStart);
                            stringStart = i + 1;
                        } else if (item == ' ')
                        {
                            if (i != stringStart)
                            {
                                Position += i - stringStart;
                                yield return new string(buffer, stringStart, i - stringStart);
                            }
                            stringStart = i + 1;
                        }
                    }

                    stringStart = 0;
                } while (readChars == bufferSize);
            }
        }
    }
}