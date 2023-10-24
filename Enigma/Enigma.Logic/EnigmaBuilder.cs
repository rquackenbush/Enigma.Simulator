using Enigma.Logic.Definitions;

namespace Enigma.Logic
{
    public static class EnigmaBuilder
    {
        /// <summary>
        /// Builds an alphabet from a string of letters.
        /// </summary>
        /// <param name="letters">The letters of the alphabet. These letters must be unique.</param>
        /// <returns></returns>
        public static Alphabet BuildAlphabet(string letters)
        {
            return new Alphabet(letters.ToArray());
        }

        public static RotorCore BuildRotorCore(string name, Alphabet alphabet, string connections)
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

            return new RotorCore(name, rotorCoreConnections);
        }

        /// <summary>
        /// Build a configured plugboard.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="connections">A string in the format of 'AB CD'</param>
        /// <returns></returns>
        public static Plugboard BuildPlugboard(Alphabet alphabet, string connections)
        {
            if (alphabet is null)
                throw new ArgumentNullException(nameof(alphabet));

            connections ??= string.Empty;

            var pairs = connections.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            //First, create a list of all the "default" connections (where no wire is connected and the plugboard just passed through the letter).
            var directConnections = Enumerable.Range(0, alphabet.Count).ToHashSet();

            var crossConnections = new List<CrossConnection>(alphabet.Count);

            foreach (var pair in pairs)
            {
                if (pair.Length != 2)
                    throw new ArgumentException($"Plugboard pair '{pair}' did not contain 2 connections.");

                var sourceLetter = pair[0];
                var targetLetter = pair[1];

                if (sourceLetter == targetLetter)
                    throw new ApplicationException($"A plugboard connection cannot map to itself: '{sourceLetter}'");

                var sourceLetterIndex = alphabet.IndexOf(sourceLetter);
                var targetLetterIndex = alphabet.IndexOf(targetLetter);

                if (!directConnections.Contains(sourceLetterIndex))
                    throw new ApplicationException($"Source letter '{sourceLetter}' has already been connected.");

                if (!directConnections.Contains(targetLetterIndex))
                    throw new ApplicationException($"Target letter '{targetLetterIndex}' has already been connected.");

                crossConnections.Add(new CrossConnection(sourceLetterIndex, targetLetterIndex));
                crossConnections.Add(new CrossConnection(targetLetterIndex, sourceLetterIndex));

                //These direct connections are no longer valid.
                directConnections.Remove(sourceLetterIndex);
                directConnections.Remove(targetLetterIndex);
            }

            foreach(var directionConnection in directConnections)
            {
                crossConnections.Add(new CrossConnection(directionConnection, directionConnection));
            }

            return new Plugboard(crossConnections.ToArray());
        }

        public static Machine BuildMachine(MachineDefinition machineDefinition, MachineConfiguration machineConfiguration)
        {
            //Alphabet
            var alphabet = BuildAlphabet(machineDefinition.Alphabet);

            var ringSettings = machineConfiguration.RingSettings.ToInidicies(alphabet);
            var ringPositions = machineConfiguration.InitialRingPositions.ToInidicies(alphabet);

            //Validate slot count
            if (machineConfiguration.WheelOrder.Length != machineDefinition.SlotCount)
                throw new InvalidOperationException($"The machine has {machineDefinition.SlotCount} slots but the configuration had {machineConfiguration.WheelOrder.Length} wheels.");

            //Get the input wheel (if one is specified)
            InputWheel? input = null;

            if (!string.IsNullOrWhiteSpace(machineConfiguration.InputName))
            {
                var inputDefinition = machineDefinition.Inputs
                    .FirstOrDefault(i => string.CompareOrdinal(i.Name, machineConfiguration.InputName) == 0);

                if (inputDefinition == null)
                    throw new InvalidOperationException($"Unable to find input wheel named '{machineConfiguration.InputName}'.");

                input = new InputWheel(inputDefinition.Name, BuildRotorCore(inputDefinition.Name, alphabet, inputDefinition.Connections));
            }

            //Get the reflector definition.
            var reflectorDefinition = machineDefinition.Reflectors
                .FirstOrDefault(r => string.CompareOrdinal(r.Name, machineConfiguration.ReflectorName) == 0);

            if (reflectorDefinition == null)
                throw new InvalidOperationException($"Unable to find reflector wheel named '{machineConfiguration.ReflectorName}'.");

            //TODO: Get the optional ring setting for the reflector
            var reflectorRingSetting = 0;
            
            if (ringSettings.Length == machineDefinition.SlotCount + 1)
            {
                reflectorRingSetting = ringSettings[machineDefinition.SlotCount] - 1;
            }

            var reflector = new Reflector(reflectorDefinition.Name, BuildRotorCore(reflectorDefinition.Name, alphabet, reflectorDefinition.Connections), reflectorRingSetting);

            var rotors = new RotorWheel[machineDefinition.SlotCount];

            for(var index = 0; index < rotors.Length; index++)
            {
                var rotorName = machineConfiguration.WheelOrder[index];

                var rotorDefinition = machineDefinition.Rotors
                    .FirstOrDefault(r => string.CompareOrdinal(r.Name, rotorName) == 0);

                if (rotorDefinition == null)
                    throw new InvalidOperationException($"Unable to find wheel '{rotorName}'.");

                var core = BuildRotorCore(rotorName, alphabet, rotorDefinition.Connections);

                var ringSettingIndex = ringSettings[index];
                var ringPositionIndex = ringPositions[index];

                var notchIndicies = alphabet.GetIndicies(rotorDefinition.Notches);

                rotors[index] = new RotorWheel(
                    rotorDefinition.Name,
                    core,
                    ringSettingIndex, 
                    ringPositionIndex,
                    notchIndicies);
  
            }

            return new Machine(machineDefinition.Name, alphabet, input, rotors, reflector, null);
        }
    }
}
