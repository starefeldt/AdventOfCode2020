using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Utility
{
    public static class InputHelper
    {
        public static IEnumerable<string> ReadAllLines(string path) => File.ReadAllLines(path);
        public static IEnumerable<string> ReadAllTextAndSplitOn(string path, string seperator)
        {

            var text = File.ReadAllText(path);
            return text.Split(seperator);
        }
    }
}
