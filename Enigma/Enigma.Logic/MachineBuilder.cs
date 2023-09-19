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
            var alphabet = BuildAlphabet(machineDefinition.Alphabet);

            if (machineConfiguration.WheelOrder.Length != machineDefinition.SlotCount)
                throw new InvalidOperationException($"The machine has {machineDefinition.SlotCount} slots but the configuration had {machineConfiguration.WheelOrder.Length} wheels.");

            InputWheel? input = null;

            if (!string.IsNullOrWhiteSpace(machineConfiguration.InputName))
            {
                var inputDefinition = machineDefinition.Inputs
              .FirstOrDefault(i => string.CompareOrdinal(i.Name, machineConfiguration.InputName) == 0);

                if (inputDefinition == null)
                    throw new InvalidOperationException($"Unable to find input wheel named '{machineConfiguration.InputName}'.");

                input = new InputWheel(BuildRotorCore(alphabet, inputDefinition.Connections));
            }

            var reflectorDefinition = machineDefinition.Reflectors
                .FirstOrDefault(r => string.CompareOrdinal(r.Name, machineConfiguration.ReflectorName) == 0);

            if (reflectorDefinition == null)
                throw new InvalidOperationException($"Unable to find reflector wheel named '{machineConfiguration.ReflectorName}'.");

            //TODO: Get the optional ring setting for the reflector
            var reflector = new Reflector(BuildRotorCore(alphabet, reflectorDefinition.Connections), 0);

            var rotors = new RotorWheel[machineDefinition.SlotCount];

            for(var index = 0; index < rotors.Length; index++)
            {
                var rotorName = machineConfiguration.WheelOrder[index];

                var rotorDefinition = machineDefinition.Rotors
                    .FirstOrDefault(r => string.CompareOrdinal(r.Name, rotorName) == 0);

                if (rotorDefinition == null)
                    throw new InvalidOperationException($"Unable to find wheel '{rotorName}'.");

                var core = BuildRotorCore(alphabet, rotorDefinition.Connections);

                var ringPositionIndex = alphabet.IndexOf(machineConfiguration.RingPositions[index]);

                var notchIndicies = alphabet.GetIndicies(rotorDefinition.Notches);

                rotors[index] = new RotorWheel(
                    core, 
                    machineConfiguration.RingSettings[index] - 1, ringPositionIndex,
                    notchIndicies);
  
            }

            return new Machine(alphabet, input, rotors, reflector, null);
        }
    }
}
