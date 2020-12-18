using AdventOfCode.Domain.Day_7;
using AdventOfCode.Utility;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindShinyBag : IPuzzle
    {
        private IEnumerable<string> _input;
        private Dictionary<string, Bag> _bags = new Dictionary<string, Bag>();

        public FindShinyBag(string fileName)
        {
            _input = InputHelper.ReadAllLines(fileName);
        }

        public long Solve()
        {
            foreach (var bagDescription in _input)
            {
                var description = bagDescription.Replace(" ", "");
                var key = description.Split("bags")[0];

                if (!_bags.TryGetValue(key, out Bag bag))
                {
                    bag = new Bag(key);
                    _bags.Add(key, bag);
                }
                AddBagContent(bag, description);
            }

            var containsShinyGold = 0;
            foreach (var bag in _bags)
            {
                if (bag.Value.ContainsAnotherBag("shinygold"))
                {
                    containsShinyGold++;
                }
            }
            return containsShinyGold;
        }

        private void AddBagContent(Bag bag, string description)
        {
            var delimiter = "contain";
            var contentStartIndex = description.IndexOf(delimiter);
            var content = description
                .Substring(contentStartIndex + delimiter.Length)
                .Replace("bags", "").Replace("bag", "").Replace(".", "")
                .Split(',')
                .Select(c => new { BagName = c.Substring(1) });

            foreach (var item in content)
            {
                if (!_bags.TryGetValue(item.BagName, out Bag b))
                {
                    b = new Bag(item.BagName);
                    _bags.Add(item.BagName, b);
                }
                bag.AddContent(b);
            }
        }
    }
}
