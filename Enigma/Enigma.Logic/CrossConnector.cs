using System.Collections.Immutable;

namespace Enigma.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CrossConnector : IConnectionMapper
    {
        private readonly ImmutableDictionary<char, char> forward;
        private readonly ImmutableDictionary<char, char> reverse;

        public CrossConnector(CrossConnection[] connections, bool allowSelfConnection)
        {
            if (connections is null) 
                throw new ArgumentNullException(nameof(connections));

            if (connections.Length == 0)
                throw new ArgumentException("At least one connection is required.");

            if (!allowSelfConnection)
            {
                foreach (var connection in connections)
                {
                    if (connection.InputLetter == connection.OutputLetter)
                        throw new ArgumentException($"A rotor core connection can not be connected to itself: {connection.InputLetter}");
                }
            }

            //Sort the forward connections
            var forwardConnections = connections
                .OrderBy(c => c.InputLetter)
                .ToArray();

            //Sort the reverse connections
            var reverseConnections = connections
                .OrderBy(c => c.OutputLetter)
                .ToArray();

            forward = connections.ToImmutableDictionary(c => c.InputLetter, c => c.OutputLetter);
            reverse = connections.ToImmutableDictionary(c => c.OutputLetter, c => c.InputLetter);
        }

        public abstract string Name { get; }

        public char MapForward(char inputLetter)
        {
            return forward[inputLetter];
        }

        public char MapReverse(char outputLetter)
        {
            return reverse[outputLetter];
        }

        public int Count => forward.Count;
    }
}