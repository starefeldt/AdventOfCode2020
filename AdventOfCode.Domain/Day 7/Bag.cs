using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day_7
{
    public class Bag
    {
        public string Name { get; }
        private readonly List<Bag> _content;

        public Bag(string name)
        {
            Name = name;
            _content = new List<Bag>();
        }

        public void AddContent(Bag bag)
        {
            _content.Add(bag);
        }

        public bool ContainsAnotherBag(string name)
        {
            if (_content.SingleOrDefault(b => b.Name == name) != null)
            {
                return true;
            }
            foreach (var bag in _content)
            {
                if (bag.ContainsAnotherBag(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
