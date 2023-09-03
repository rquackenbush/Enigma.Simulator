namespace Enigma.Logic
{

    public class EnigmaRotor : EnigmaRotorBase
    {
        /// <summary>
        /// Represents a rotor in an Enigma machine.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public EnigmaRotor(string name, EnigmaRotorPosition[] positions) 
            : base(name, positions) 
        {
        }

        public int MapReverse(int value)
        {
            throw new NotImplementedException();
        }
    }
}