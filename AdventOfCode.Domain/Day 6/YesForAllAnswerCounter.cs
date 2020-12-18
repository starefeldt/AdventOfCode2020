using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class YesForAllAnswerCounter : IPuzzle
    {
        private IEnumerable<string> _input;

        public YesForAllAnswerCounter(string fileName)
        {
            _input = InputHelper.ReadAllTextAndSplitOn(fileName, Environment.NewLine + Environment.NewLine);
        }

        public long Solve()
        {
            var yesAnswers = 0;
            foreach (var answers in _input)
            {
                var individualsInGroup = answers.Split(Environment.NewLine);
                var firstIndividual = individualsInGroup.First().ToList();  //We can compare all answers to the first since it's all or nothing
                for (int i = 1; i < individualsInGroup.Length; i++)
                {
                    firstIndividual = firstIndividual.Intersect(individualsInGroup[i]).ToList();    //keep those that match
                }
                yesAnswers += firstIndividual.Count;
            }
            return yesAnswers;
        }
    }
}
