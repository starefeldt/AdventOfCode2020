using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Utility
{
    public static class InputHelper
    {
        public static IEnumerable<string> ReadAllLines(string path) =>
            File.ReadAllLines(path);

        public static IEnumerable<IEnumerable<string>> ReadAllLinesAndSplitOn(string path, string seperator)
        {
            var lines = File.ReadAllLines(path);
            return lines.Select(l => l.Split(seperator));
        }

        public static IEnumerable<string> ReadAllTextAndSplitOn(string path, string seperator) =>
            File.ReadAllText(path).Split(seperator);
    }
}
