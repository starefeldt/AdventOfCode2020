using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class YesAnswerCounter : IPuzzle
    {
        private IEnumerable<string> _input;

        public YesAnswerCounter(string fileName)
        {
            _input = InputHelper.ReadAllTextAndSplitOn(fileName, Environment.NewLine + Environment.NewLine);
        }

        public long Solve()
        {
            var yesAnswers = 0;
            foreach (var answers in _input)
            {
                var distinctAnswers = answers.Replace(Environment.NewLine, "").ToHashSet();
                yesAnswers += distinctAnswers.Count;
            }
            return yesAnswers;
        }
    }
}
