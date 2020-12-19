using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day_7
{
    public class Bag
    {
        public string Name { get; }
        public List<Bag> Content { get; } = new List<Bag>();

        public Bag(string name)
        {
            Name = name;
        }

        public void AddContent(Bag bag)
        {
            Content.Add(bag);
        }

        public bool ContainsAnotherBag(string name)
        {
            var distinct = Content.Distinct();
            if (distinct.SingleOrDefault(b => b.Name == name) != null)
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
            contentCount += Content.Count;
            foreach (var bag in Content)
            {
                bag.GetContentCount(ref contentCount);
            }
        }
    }
}
