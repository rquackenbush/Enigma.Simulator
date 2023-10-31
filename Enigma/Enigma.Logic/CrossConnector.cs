using System.Collections.Immutable;

namespace Enigma.Logic
{
    public abstract class CrossConnector
    {
        protected readonly string alphabet;
        protected readonly ImmutableArray<int> forwardMap;
        protected readonly ImmutableArray<int> reverseMap;

        public CrossConnector(string alphabet, string wiring)
        {
            this.alphabet = alphabet;
            Wiring = wiring;

            EnigmaValidator.ValidateWiring(alphabet, wiring);

            forwardMap = wiring
              .Select(c => alphabet.IndexOf(c))
              .ToImmutableArray();

            reverseMap = forwardMap
                .Select((item, index) => new { Index = index, Value = item })
                .OrderBy(c => c.Value)
                .Select(c => c.Index)
                .ToImmutableArray();
        }

        public abstract string Name { get; }

        public string Wiring { get; }

        public virtual int SignalForward(int n)
        {
            return forwardMap[n];
        }

        public virtual int SignalReverse(int n)
        {
            return reverseMap[n];
        }
    }
}