using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day_7
{
    public class Bag
    {
        private readonly string _name;
        private readonly List<Bag> _content;

        public Bag(string name)
        {
            _name = name;
            _content = new List<Bag>();
        }

        public void AddContent(Bag bag)
        {
            _content.Add(bag);
        }

        public bool ContainsAnotherBag(string name)
        {
            var distinct = _content.Distinct();
            if (distinct.SingleOrDefault(b => b._name == name) != null)
            {
                return true;
            }
            foreach (var bag in distinct)
            {
                if (bag.ContainsAnotherBag(name))
                {
                    return true;
                }
            }
            return false;
        }

        public void GetContentCount(ref int contentCount)
        {
            contentCount += _content.Count;
            foreach (var bag in _content)
            {
                bag.GetContentCount(ref contentCount);
            }
        }
    }
}
