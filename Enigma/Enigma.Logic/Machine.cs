namespace Enigma.Logic
{
    public class Machine
    {
        public Machine(Alphabet alphabet, InputWheel input, RotorWheel[] rotors, Reflector reflector, Plugboard? plugboard)
        {
            Alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
            Input = input ?? throw new ArgumentNullException(nameof(input));
            Rotors = rotors ?? throw new ArgumentNullException(nameof(rotors));
            Reflector = reflector ?? throw new ArgumentNullException(nameof(reflector));
            Plugboard = plugboard;
        }

        public Alphabet Alphabet { get; }

        public InputWheel Input { get; }

        public RotorWheel[] Rotors { get; }

        public Reflector Reflector { get; }

        public Plugboard? Plugboard { get; }

        public char TypeLetter(char inputLetter)
        {
            //Move wheels
            bool advanceNext = true;

            for (var rotorIndex = 0; rotorIndex < Rotors.Length; rotorIndex++)
            {
                if (advanceNext)
                {
                    advanceNext = Rotors[rotorIndex].Advance();
                }
                else
                    break;
            }

            /*
              Signal path:

              -->         -->     -->        -->        -->        -->
              plugboard | input | rotor[0] | rotor[1] | rotor[2] | reflector
              <--         <--     <--        <--        <--        <--
            */

            //This will carry the current connection index throughout the process.
            var currentIndex = Alphabet.IndexOf(inputLetter);

            //Plugboard in
            if (Plugboard != null)
            {
                currentIndex = Plugboard.MapForward(currentIndex);
            }

            //Input
            currentIndex = Input.MapForward(currentIndex);

            //Rotors
            for (var rotorIndex = 0; rotorIndex < Rotors.Length; rotorIndex++)
            {
                currentIndex = Rotors[rotorIndex].MapForward(currentIndex);
            }

            //Reflector
            currentIndex = Reflector.MapForward(currentIndex);

            //Rotors
            for (var rotorIndex = Rotors.Length - 1; rotorIndex > 0; rotorIndex--)
            {
                currentIndex = Rotors[rotorIndex].MapReverse(currentIndex);
            }

            //Input
            currentIndex = Input.MapReverse(currentIndex);

            if (Plugboard != null)
            {
                currentIndex = Plugboard.MapReverse(currentIndex);
            }


            return Alphabet[currentIndex].Letter;     
        }
    }
}