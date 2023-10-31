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

            foreach (var connectionLetter in connectionLetters)
            {
                var rotorCoreConnection = new CrossConnection(alphabet[positionIndex].Letter, connectionLetter);

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
        public static Plugboard? BuildPlugboard(Alphabet alphabet, string? connections)
        {
            if (alphabet is null)
                throw new ArgumentNullException(nameof(alphabet));

            if (connections == null)
                return null;

            var pairs = connections.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            //First, create a list of all the "default" connections (where no wire is connected and the plugboard just passed through the letter).
            var directConnections = alphabet
                .Select(l => l.Letter)
                .ToHashSet();

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

                if (!directConnections.Contains(sourceLetter))
                    throw new ApplicationException($"Source letter '{sourceLetter}' has already been connected.");

                if (!directConnections.Contains(targetLetter))
                    throw new ApplicationException($"Target letter '{targetLetterIndex}' has already been connected.");

                crossConnections.Add(new CrossConnection(sourceLetter, targetLetter));
                crossConnections.Add(new CrossConnection(targetLetter, sourceLetter));

                //These direct connections are no longer valid.
                directConnections.Remove(sourceLetter);
                directConnections.Remove(targetLetter);
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
            var wheelPositions = machineConfiguration.InitialWheelPositions.ToInidicies(alphabet);

            if (ringSettings.Length == machineDefinition.SlotCount)
            {
                ringSettings = ringSettings
                    .Prepend(0)
                    .ToArray();
            }
            else if (ringSettings.Length == machineDefinition.SlotCount + 1)
            {
                //We're good
            }
            else
                throw new InvalidOperationException($"The number of ring settings was {ringSettings.Length}. Expected {wheelPositions.Length} or {wheelPositions.Length + 1}.");

            if (wheelPositions.Length == machineDefinition.SlotCount)
            {
                wheelPositions = wheelPositions
                    .Prepend(0)
                    .ToArray();
            }
            else if (wheelPositions.Length == machineDefinition.SlotCount + 1)
            {
                //We're good.
            }
            else
                throw new InvalidOperationException($"The number of wheel positions was {wheelPositions.Length}. Expected {wheelPositions.Length} or {wheelPositions.Length + 1}.");

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

                input = new InputWheel(alphabet, inputDefinition.Name, BuildRotorCore(inputDefinition.Name, alphabet, inputDefinition.Connections));
            }

            //Get the reflector definition.
            var reflectorDefinition = machineDefinition.Reflectors
                .FirstOrDefault(r => string.CompareOrdinal(r.Name, machineConfiguration.ReflectorName) == 0);

            if (reflectorDefinition == null)
                throw new InvalidOperationException($"Unable to find reflector wheel named '{machineConfiguration.ReflectorName}'.");

            var reflector = new Reflector(alphabet, reflectorDefinition.Name, BuildRotorCore(reflectorDefinition.Name, alphabet, reflectorDefinition.Connections), ringSettings[0], wheelPositions[0]);

            var rotors = new RotorWheel[machineDefinition.SlotCount];

            for(var index = 0; index < rotors.Length; index++)
            {
                var rotorName = machineConfiguration.WheelOrder[index];

                var rotorDefinition = machineDefinition.Rotors
                    .FirstOrDefault(r => string.CompareOrdinal(r.Name, rotorName) == 0);

                if (rotorDefinition == null)
                    throw new InvalidOperationException($"Unable to find wheel '{rotorName}'.");

                var core = BuildRotorCore(rotorName, alphabet, rotorDefinition.Connections);

                //The first element in these arrays is always for the reflector
                var ringSettingIndex = ringSettings[index + 1];
                var ringPositionIndex = wheelPositions[index + 1];

                var notchIndicies = alphabet.GetIndicies(rotorDefinition.Notches);

                rotors[index] = new RotorWheel(
                    alphabet,
                    rotorDefinition.Name,
                    core,
                    ringSettingIndex, 
                    ringPositionIndex,
                    notchIndicies);
  
            }

            var plugboard = BuildPlugboard(alphabet, machineConfiguration.Plugboard);

            return new Machine(machineDefinition.Name, alphabet, input, rotors, reflector, plugboard);
        }
    }
}
