//namespace Enigma.Logic
//{
//    public class EnigmaMachineInstance
//    {
//        private readonly int[] rotorIndicies;

//        public EnigmaMachineInstance(EnigmaMachine machine, Input input, Rotor[] rotors, Reflector reflector, int[] initialRotorIndicies)
//        {
//            Machine = machine ?? throw new ArgumentNullException(nameof(machine));
//            Input = input ?? throw new ArgumentNullException(nameof(input));
//            Rotors = rotors ?? throw new ArgumentNullException(nameof(rotors));
//            Reflector = reflector ?? throw new ArgumentNullException(nameof(reflector));
//            rotorIndicies = initialRotorIndicies ?? throw new ArgumentNullException(nameof(initialRotorIndicies));
//        }

//        public EnigmaMachine Machine { get; }

//        public Input Input { get; }

//        public Rotor[] Rotors { get; }

//        public Reflector Reflector { get;  }

//        public char TypeLetter(char input)
//        {
//            var current = Machine.Alphabet.IndexOf(input);

//            //Input
//            current = Input.Map(current);

//            //Rotors
//            for(var rotorIndex = 0;  rotorIndex < Rotors.Length; rotorIndex++)
//            {
//                current = Rotors[rotorIndex].Map(current);
//            }

//            //Reflector
//            current = Reflector.Map(current);

//            //Rotors
//            //TODO: Do the reverse
//            for(var rotorIndex = Rotors.Length - 1;  rotorIndex >= 0; rotorIndex--) 
//            {
//                current = Rotors[rotorIndex].MapReverse(current);
//            }

//            //Input
//            current = Input.MapReverse(current);

//            //Done
//            return Machine.Alphabet[current].Letter;
//        }
//    }
//}
