//using System.Collections.Immutable;

//namespace Enigma.Logic
//{
//    public class EnigmaMachine
//    {
//        public EnigmaMachine(string name, Alphabet alphabet, Input[] etws, Rotor[] rotors, Reflector[] ukws)
//        {
//            if (rotors.Length < 3)
//                throw new ArgumentException("Please specify at least three rotors.");

//            var positionCount = rotors[0].Positions.Length;

//            if (rotors.Any(r => r.Positions.Length != positionCount))
//                throw new ArgumentException("All rotors must have the same number of positions");

//            if (etws == null)
//                throw new ArgumentNullException(nameof(etws));

//            if (ukws == null)
//                throw new ArgumentNullException(nameof(ukws));

//            Name = name;
//            Alphabet = alphabet;
//            ETWs = ImmutableArray.Create(etws);
//            Rotors = ImmutableArray.Create(rotors);
//            UKWs = ImmutableArray.Create(ukws);
//        }

//        public string Name { get; }
        
//        public Alphabet Alphabet { get; }

//        public ImmutableArray<Input> ETWs { get; }

//        public ImmutableArray<Rotor> Rotors { get; }

//        public ImmutableArray<Reflector> UKWs { get; }    
//    }

//    public class MachineType
//    {
//        public string Name { get; }

//        public Alphabet Alphabet { get; }
//    }
//}
