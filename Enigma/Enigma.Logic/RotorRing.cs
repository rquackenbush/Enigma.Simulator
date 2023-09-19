//using System.Collections.Immutable;

//namespace Enigma.Logic
//{
//    public class RotorRing
//    {
//        public RotorRing(Alphabet alphabet, int[] notchIndicies)
//        {
//            if (alphabet is null) throw new ArgumentNullException(nameof(alphabet));
            
//            if (notchIndicies.Length == 0)
//                throw new ArgumentException("A RotorRing must have at least 1 notch.");

//            if (notchIndicies.Max() >= alphabet.Count)
//                throw new ArgumentException("Invalid notch index");

//            var positions = new RotorPosition[alphabet.Count];

//            for(var index = 0; index < alphabet.Count; index++)
//            {
//                positions[index] = new RotorPosition(alphabet[index], notchIndicies.Contains(index));
//            }

//            Positions = ImmutableArray.Create(positions);
//        }

//        public ImmutableArray<RotorPosition> Positions { get; }
//    }
//}