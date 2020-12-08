using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Utility
{
    public static class InputHelper
    {
        public static IEnumerable<string> ReadAllLines(string path) => File.ReadAllLines(path);
    }
}
