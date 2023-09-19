using System.Collections.Immutable;

namespace Enigma.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CrossConnector : IConnectionMapper
    {
        private readonly ImmutableArray<int> forward;
        private readonly ImmutableArray<int> reverse;

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
                    if (connection.InputIndex == connection.OutputIndex)
                        throw new ArgumentException($"A rotor core connection can not be connected to itself: {connection.InputIndex}");
                }
            }

            //Sort the forward connections
            var forwardConnections = connections
                .OrderBy(c => c.InputIndex)
                .ToArray();

            //Sort the reverse connections
            var reverseConnections = connections
                .OrderBy(c => c.OutputIndex)
                .ToArray();

            for(int index = 0; index < forwardConnections.Length; index++)
            {
                if (forwardConnections[index].InputIndex != index)
                    throw new ArgumentException($"Invalid InputIndex {forwardConnections[index].InputIndex}");

                if (reverseConnections[index].OutputIndex != index)
                    throw new ArgumentException($"Invalid OutputIndex {reverseConnections[index].OutputIndex}");
            }

            forward = ImmutableArray.Create(forwardConnections
                .Select(c => c.OutputIndex)
                .ToArray());

            reverse = ImmutableArray.Create(reverseConnections
                .Select(c => c.InputIndex)
                .ToArray());
        }

        public int MapForward(int inputIndex)
        {
            return forward[inputIndex];
        }

        public int MapReverse(int outputIndex)
        {
            return reverse[outputIndex];
        }

        public int Count => forward.Length;
    }
}