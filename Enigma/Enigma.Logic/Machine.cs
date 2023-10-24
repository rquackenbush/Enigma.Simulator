using System;

namespace Enigma.Logic
{
    public class Machine
    {
        private readonly EffectiveMapper[] mappers;

        public Machine(string name, Alphabet alphabet, InputWheel? input, RotorWheel[] rotors, Reflector reflector, Plugboard? plugboard)
        {
            Name = name;
            Alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
            Input = input;
            Rotors = rotors ?? throw new ArgumentNullException(nameof(rotors));
            Reflector = reflector ?? throw new ArgumentNullException(nameof(reflector));
            Plugboard = plugboard;

            /*
             Signal path:

             -->         -->     -->        -->        -->        -->
             plugboard | input | rotor[0] | rotor[1] | rotor[2] | reflector
             <--         <--     <--        <--        <--        <--
           */

            var temp = new List<EffectiveMapper>();

            if (plugboard != null)
                temp.Add(new EffectiveMapper(plugboard, Direction.In));

            if (input != null)
                temp.Add(new EffectiveMapper(input, Direction.In));

            foreach(var rotor in rotors.Reverse())
            {
                temp.Add(new EffectiveMapper(rotor, Direction.In));
            }

            if (reflector != null) 
            {
                temp.Add(new EffectiveMapper(reflector.Core, Direction.Reflect));
            }

            foreach (var rotor in rotors)
            {
                temp.Add(new EffectiveMapper(rotor, Direction.Out));
            }

            mappers = temp.ToArray();
        }

        public string Name { get; }

        public Alphabet Alphabet { get; }

        public InputWheel? Input { get; }

        public RotorWheel[] Rotors { get; }

        public Reflector Reflector { get; }

        public Plugboard? Plugboard { get; }

        public TypeLetterResult TypeLetter(char inputLetter)
        {
            var operations = new List<InnerOperation>(mappers.Length );

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

            //This will carry the current connection index throughout the process.
            var currentIndex = Alphabet.IndexOf(inputLetter);

            foreach(var mapper in mappers)
            {
                var currentIndexBefore = currentIndex;

                currentIndex = mapper.Map(currentIndex);

                operations.Add(new InnerOperation(mapper.Source.Name, currentIndexBefore, currentIndex, mapper.Direction));
            }

            return new TypeLetterResult(this, inputLetter, Alphabet[currentIndex].Letter, operations.ToArray());     
        }
    }
}