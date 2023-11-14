using System.Collections.Immutable;

namespace Enigma.Simulator
{
    /// <summary>
    /// Base class for anything that does cross connection of wires.
    /// </summary>
    public abstract class CrossConnector
    {
        /// <summary>
        /// The alphabeta associatd with this <see cref="CrossConnector"/>.
        /// </summary>
        protected readonly string alphabet;

        /// <summary>
        /// The map of forward connections.
        /// </summary>
        protected readonly ImmutableArray<int> forwardMap;

        /// <summary>
        /// The map of reverse connections.
        /// </summary>
        protected readonly ImmutableArray<int> reverseMap;

        /// <summary>
        /// Creates an instance of the <see cref="CrossConnector"/> class.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
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

        /// <summary>
        /// Gets the name of this cross connector.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The wiring that was used to create this <see cref="CrossConnector"/>.
        /// </summary>
        public string Wiring { get; }

        /// <summary>
        /// Map the signal in a forward (right to left) direction.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual int SignalForward(int n)
        {
            return forwardMap[n];
        }

        /// <summary>
        /// Map the signal in a reverse (left to right) direction.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual int SignalReverse(int n)
        {
            return reverseMap[n];
        }
    }
}