using AdventOfCode.Domain.Day_7;
using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindShinyBag : IPuzzle
    {
        private readonly Func<Dictionary<string, Bag>, int> _getResultFromBags;
        private IEnumerable<string> _input;
        private readonly Dictionary<string, Bag> _bags;

        public FindShinyBag(string fileName, Func<Dictionary<string, Bag>, int> getResultFromBags)
        {
            _input = InputHelper.ReadAllLines(fileName);
            _getResultFromBags = getResultFromBags;
            _bags = new Dictionary<string, Bag>();
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
            return _getResultFromBags(_bags);
        }

        private void AddBagContent(Bag bag, string description)
        {
            var delimiter = "contain";
            var contentStartIndex = description.IndexOf(delimiter);
            var content = description
                .Substring(contentStartIndex + delimiter.Length)
                .Replace("bags", "").Replace("bag", "").Replace(".", "")
                .Split(',')
                .Select(c => new
                {
                    BagAmount = int.TryParse(c[0].ToString(), out int amount) == true ? amount : 0,
                    BagName = c.Substring(1)
                });

            foreach (var item in content)
            {
                if (!_bags.TryGetValue(item.BagName, out Bag b))
                {
                    b = new Bag(item.BagName);
                    _bags.Add(item.BagName, b);
                }
                for (int i = 0; i < item.BagAmount; i++)
                {
                    bag.AddContent(b);
                }
            }
        }
    }
}
