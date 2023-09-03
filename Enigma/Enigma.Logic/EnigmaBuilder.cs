using System.Xml.Linq;

namespace Enigma.Logic
{
    public static class EnigmaBuilder
    {
        public static EnigmaAlphabet BuildAlphabet(string letters)
        {
            return  new EnigmaAlphabet(letters.ToArray());
        }

        public static EnigmaRotor BuildRotor(EnigmaAlphabet alphabet, EnigmaRotorDefinition rotorDefintion)
        {
            return BuildRotor(alphabet, rotorDefintion.Name, rotorDefintion.Connections, rotorDefintion.Notches);
        }

        public static EnigmaRotor BuildRotor(EnigmaAlphabet alphabet, string name, string connections, string notches)
        {
            var connectionLetters = connections.ToArray();

            if (connectionLetters.Length != alphabet.Count)
                throw new ArgumentException($"connections had {connectionLetters.Length} elements but the alphabet had {alphabet.Count} letters. They must match.");

            var notchIndicies = new HashSet<int>();

            foreach(var notch in notches)
            {
                notchIndicies.Add(alphabet.IndexOf(notch));
            }

            var positions = new EnigmaRotorPosition[connections.Length];

            var positionIndex = 0;

            foreach(var connection in connections)
            {
                var outputIndex = alphabet.IndexOf(connection);

                var position = new EnigmaRotorPosition(alphabet[positionIndex], outputIndex, notchIndicies.Contains(positionIndex));

                positions[positionIndex] = position;

                positionIndex++;
            }

            return new EnigmaRotor(name, positions);
        }

        public static EnigmaRotor[] BuildRotors(EnigmaAlphabet alphabet, EnigmaRotorDefinition[] rotorDefinitions)
        {
            var rotors = new EnigmaRotor[rotorDefinitions.Length];

            for(var rotorIndex = 0; rotorIndex < rotorDefinitions.Length; rotorIndex++)
            {
                rotors[rotorIndex] = BuildRotor(alphabet, rotorDefinitions[rotorIndex]);
            }

            return rotors;
        }

        public static EnigmaInput BuildETW(EnigmaAlphabet alphabet, InputDefinition enigmaETWDefinition)
        {
            return BuildETW(alphabet, enigmaETWDefinition.Name, enigmaETWDefinition.Connections);
        }

        public static EnigmaInput BuildETW(EnigmaAlphabet alphabet, string name, string connections)
        {
            var connectionLetters = connections.ToArray();

            if (connectionLetters.Length != alphabet.Count)
                throw new ArgumentException($"connections had {connectionLetters.Length} elements but the alphabet had {alphabet.Count} letters. They must match.");

            var positions = new EnigmaRotorPosition[connections.Length];

            var positionIndex = 0;

            foreach (var connection in connections)
            {
                var outputIndex = alphabet.IndexOf(connection);

                var position = new EnigmaRotorPosition(alphabet[positionIndex], outputIndex, false);

                positions[positionIndex] = position;

                positionIndex++;
            }

            return new EnigmaInput(name, positions);
        }

        public static EnigmaInput[] BuildETWs(EnigmaAlphabet alphabet, InputDefinition[] definitions)
        {
            var rotors = new EnigmaInput[definitions.Length];

            for (var rotorIndex = 0; rotorIndex < definitions.Length; rotorIndex++)
            {
                rotors[rotorIndex] = BuildETW(alphabet, definitions[rotorIndex]);
            }

            return rotors;
        }

        public static EnigmaReflector BuildUKW(EnigmaAlphabet alphabet, string name, string connections)
        {
            var connectionLetters = connections.ToArray();

            if (connectionLetters.Length != alphabet.Count)
                throw new ArgumentException($"connections had {connectionLetters.Length} elements but the alphabet had {alphabet.Count} letters. They must match.");

            var positions = new EnigmaRotorPosition[connections.Length];

            var positionIndex = 0;

            foreach (var connection in connections)
            {
                var outputIndex = alphabet.IndexOf(connection);

                var position = new EnigmaRotorPosition(alphabet[positionIndex], outputIndex, false);

                positions[positionIndex] = position;

                positionIndex++;
            }

            return new EnigmaReflector(name, positions);
        }

        public static EnigmaReflector BuildUKW(EnigmaAlphabet alphabet, ReflectorDefinition enigmaETWDefinition)
        {
            return BuildUKW(alphabet, enigmaETWDefinition.Name, enigmaETWDefinition.Connections);
        }

        public static EnigmaReflector[] BuildUKWs(EnigmaAlphabet alphabet, ReflectorDefinition[] definitions)
        {
            var rotors = new EnigmaReflector[definitions.Length];

            for (var rotorIndex = 0; rotorIndex < definitions.Length; rotorIndex++)
            {
                rotors[rotorIndex] = BuildUKW(alphabet, definitions[rotorIndex]);
            }

            return rotors;
        }

        public static int GetRotorPosition(EnigmaAlphabet alphabet, char letter)
        {
            return alphabet.IndexOf(letter);
        }

        public static int[] GetRotorPositions(EnigmaAlphabet alphabet, string rotorPositions)
        {
            var positions = new int[rotorPositions.Length];

            for(int index = 0; index < rotorPositions.Length; index++)
            {
                positions[index] = GetRotorPosition(alphabet, rotorPositions[index]);
            }

            return positions;
        }

        //private static EnigmaRotor[] GetRotors(EnigmaRotor[] rotors, string[] names)
        //{
        //    var toReturn = new EnigmaRotor[names.Length];

        //    for(var index = 0; index < names.Length; index++)
        //    {
        //        var rotor = rotors.FirstOrDefault(r => r.Name == names[index]);

        //        if (rotor == null)
        //            throw new Exception($"Unable to find rotor with name '${names[index]}'");

        //        toReturn[index] = rotor;
        //    }

        //    return toReturn;
        //}

        public static EnigmaMachine BuildMachine(this EnigmaMachineDefinition machineDefinition)
        {
            if (machineDefinition.Name == null)
                throw new Exception("The machine ");

            if (machineDefinition.Alphabet == null)
                throw new Exception("Alphatbet was null");

            if (machineDefinition.Rotors == null)
                throw new Exception("Rotors was null.");

            if (machineDefinition.Inputs == null)
                throw new Exception("ETWs was null");

            if (machineDefinition.Reflectors == null)
                throw new Exception("UKWs was null");

            //if (machineDefinition.InitialRotorPositions == null)
            //    throw new Exception("Initial Rotor Positions was null.");

            //if (machineDefinition.RotorNames == null)
            //    throw new Exception("RoterNames was null. Please specify the roters to be installed into the machine.");

            var alphabet = BuildAlphabet(machineDefinition.Alphabet);

            var etws = BuildETWs(alphabet, machineDefinition.Inputs);

            var allRotors = BuildRotors(alphabet, machineDefinition.Rotors);

            var ukws = BuildUKWs(alphabet, machineDefinition.Reflectors);

            //var rotorPositions = GetRotorPositions(alphabet, machineDefinition.InitialRotorPositions);

            return new EnigmaMachine(machineDefinition.Name, alphabet, etws, allRotors, ukws);
        }

        public static EnigmaMachineInstance BuildMachineInstance(this EnigmaMachineInstanceDefinition machineInstanceDefinition)
        {
            if (machineInstanceDefinition.Machine == null)
                throw new Exception("No machine was provided.");

            if (machineInstanceDefinition.InputName == null)
                throw new Exception("No ETWName was provided.");

            if (machineInstanceDefinition.ReflectorName == null)
                throw new Exception("No UKWName was provided.");

            if (machineInstanceDefinition.Machine.ETWs == null)
                throw new Exception("No ETWs were provided.");

            if (machineInstanceDefinition.Machine.UKWs == null)
                throw new Exception("No UKWs were provided.");

            if (machineInstanceDefinition.RotorNames == null)
                throw new Exception("No RotorNames were provided.");

            if (machineInstanceDefinition.Machine.Rotors == null)
                throw new Exception("No rotors were provided.");

            if (machineInstanceDefinition.InitialRotorPositions == null)
                throw new Exception("The InitialRotorPositions propety was null and that's bullshit.");

            if (machineInstanceDefinition.InitialRotorPositions.Length != machineInstanceDefinition.RotorNames.Length)
                throw new Exception("The number of intial rotor positions was not equal to the number of rotor names.");

            //Get the input
            var etw = machineInstanceDefinition.Machine.ETWs
                .First(e => e.Name == machineInstanceDefinition.InputName);

            //Get the reflector
            var ukw = machineInstanceDefinition.Machine.UKWs
                .First(u => u.Name == machineInstanceDefinition.ReflectorName);

            //Get the rotors
            var rotors = new EnigmaRotor[machineInstanceDefinition.RotorNames.Length];

            for(var rotorIndex = 0; rotorIndex < machineInstanceDefinition.RotorNames.Length; rotorIndex++)
            {
                rotors[rotorIndex] = machineInstanceDefinition.Machine.Rotors
                    .First(r => r.Name == machineInstanceDefinition.RotorNames[rotorIndex]);
            }

            //var initialRotorIndicies = new int[machineInstanceDefinition.InitialRotorPositions.Length];

            //for(var rotorNameIndex = 0; rotorNameIndex < machineInstanceDefinition.RotorNames.Length; rotorNameIndex++)
            //{
            //    initialRotorIndicies[rotorNameIndex] = machineInstanceDefinition.Machine.Alphabet.IndexOf(machineInstanceDefinition.InitialRotorPositions[rotorNameIndex]);
            //}

            var initialRotorIndicies = machineInstanceDefinition.InitialRotorPositions
                .Select(i => i - 1)
                .ToArray();

            return new EnigmaMachineInstance(machineInstanceDefinition.Machine, etw, rotors, ukw, initialRotorIndicies);
        }
    }
}
