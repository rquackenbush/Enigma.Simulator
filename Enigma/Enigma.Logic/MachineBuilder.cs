using Enigma.Logic.Configuration;
using Enigma.Logic.Definitions;

namespace Enigma.Logic
{
    public static class MachineBuilder
    {
        public static Alphabet BuildAlphabet(string letters)
        {
            return new Alphabet(letters.ToArray());
        }

        public static RotorCore BuildRotorCore(Alphabet alphabet, string connections)
        {
            var connectionLetters = connections.ToArray();

            if (connectionLetters.Length != alphabet.Count)
                throw new ArgumentException($"connections had {connectionLetters.Length} elements but the alphabet had {alphabet.Count} letters. They must match.");

            var rotorCoreConnections = new CrossConnection[connections.Length];

            var positionIndex = 0;

            foreach (var connection in connections)
            {
                var outputIndex = alphabet.IndexOf(connection);

                var rotorCoreConnection = new CrossConnection(positionIndex, outputIndex);

                rotorCoreConnections[positionIndex] = rotorCoreConnection;

                positionIndex++;
            }

            return new RotorCore(rotorCoreConnections);
        }

        public static Machine BuildMachine(MachineDefinition machineDefinition, MachineConfiguration machineConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
