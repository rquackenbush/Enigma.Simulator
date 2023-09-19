namespace Enigma.Logic
{
    public class Machine
    {
        private readonly IConnectionMapper[] connectionMappers;

        public Machine(Alphabet alphabet, InputWheel? input, RotorWheel[] rotors, Reflector reflector, Plugboard? plugboard)
        {
            Alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
            Input = input;
            Rotors = rotors ?? throw new ArgumentNullException(nameof(rotors));
            Reflector = reflector ?? throw new ArgumentNullException(nameof(reflector));
            Plugboard = plugboard;

            var temp = new List<IConnectionMapper>();

            if (plugboard != null)
                temp.Add(plugboard);

            if (input != null)
                temp.Add(input);

            foreach(var rotor in rotors.Reverse())
            {
                temp.Add(rotor);
            }

            connectionMappers = temp.ToArray();
        }

        public Alphabet Alphabet { get; }

        public InputWheel? Input { get; }

        public RotorWheel[] Rotors { get; }

        public Reflector Reflector { get; }

        public Plugboard? Plugboard { get; }

        public char TypeLetter(char inputLetter)
        {
            //Move wheels
            bool advanceNext = true;

            for (var rotorIndex = Rotors.Length - 1; rotorIndex >= 0; rotorIndex--)
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

            for(var index = 0; index < connectionMappers.Length; index++)
            {
                currentIndex = connectionMappers[index].MapForward(currentIndex);
            }

            currentIndex = Reflector.MapForward(currentIndex);

            for (var index = connectionMappers.Length - 1; index >= 0; index--)
            {
                currentIndex = connectionMappers[index].MapReverse(currentIndex);
            }

            return Alphabet[currentIndex].Letter;     
        }
    }
}