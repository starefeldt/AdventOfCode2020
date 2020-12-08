using System.Linq;

namespace AdventOfCode.Domain.Day_2
{
    public class Instruction
    {
        private readonly int _minOccurence;
        private readonly int _maxOccurence;
        private readonly char _search;
        private readonly string _password;

        public Instruction(int minOccurence, int maxOccurence, char search, string password)
        {
            _minOccurence = minOccurence;
            _maxOccurence = maxOccurence;
            _search = search;
            _password = password;
        }

        public bool IsPasswordValid()
        {
            var occurences = _password.Where(x => x == _search).Count();
            return occurences >= _minOccurence && occurences <= _maxOccurence;
        }
    }
}
