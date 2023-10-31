using Enigma.Logic.Definitions;

namespace Enigma.Logic
{
    public static class EnigmaBuilder
    {
        /// <summary>
        /// Build a configured plugboard.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="connections">A string in the format of 'AB CD'</param>
        /// <returns></returns>
        public static Plugboard? BuildPlugboard(string alphabet, string? connections)
        {
            if (alphabet is null)
                throw new ArgumentNullException(nameof(alphabet));

            if (connections == null)
                return null;

            //Start off with the alphabet as is
            var wiring = alphabet.ToArray();

            var pairs = connections.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

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

                wiring[sourceLetterIndex] = targetLetter;
                wiring[targetLetterIndex] = sourceLetter;
                
            }

            return new Plugboard(alphabet, new string(wiring));
        }

        public static Machine BuildMachine(MachineDefinition machineDefinition, MachineConfiguration machineConfiguration)
        {
            var ringSettings = machineConfiguration.RingSettings.ToInidicies(machineDefinition.Alphabet);
            var wheelPositions = machineConfiguration.InitialWheelPositions.ToInidicies(machineDefinition.Alphabet);

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

                input = new InputWheel(inputDefinition.Name, machineDefinition.Alphabet, inputDefinition.Wiring);
            }

            //Get the reflector definition.
            var reflectorDefinition = machineDefinition.Reflectors
                .FirstOrDefault(r => string.CompareOrdinal(r.Name, machineConfiguration.ReflectorName) == 0);

            if (reflectorDefinition == null)
                throw new InvalidOperationException($"Unable to find reflector wheel named '{machineConfiguration.ReflectorName}'.");

            var reflector = new Reflector(reflectorDefinition.Name, machineDefinition.Alphabet,reflectorDefinition.Wiring, ringSettings[0], wheelPositions[0]);

            var rotors = new Rotor[machineDefinition.SlotCount];

            for(var index = 0; index < rotors.Length; index++)
            {
                var rotorName = machineConfiguration.WheelOrder[index];

                var rotorDefinition = machineDefinition.Rotors
                    .FirstOrDefault(r => string.CompareOrdinal(r.Name, rotorName) == 0);

                if (rotorDefinition == null)
                    throw new InvalidOperationException($"Unable to find wheel '{rotorName}'.");

                //The first element in these arrays is always for the reflector
                var ringSettingIndex = ringSettings[index + 1];
                var wheelPositionIndex = wheelPositions[index + 1];

                var notchIndicies = machineDefinition.Alphabet.GetIndicies(rotorDefinition.Notches);

                rotors[index] = new Rotor(
                    rotorDefinition.Name,
                    machineDefinition.Alphabet,
                    rotorDefinition.Wiring,
                    notchIndicies,
                    ringSettingIndex,
                    wheelPositionIndex);
  
            }

            var plugboard = BuildPlugboard(machineDefinition.Alphabet, machineConfiguration.Plugboard);

            return new Machine(machineDefinition.Name, machineDefinition.Alphabet, input, rotors, reflector, plugboard);
        }
    }
}
