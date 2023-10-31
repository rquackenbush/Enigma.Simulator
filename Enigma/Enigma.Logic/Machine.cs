using System;

namespace Enigma.Logic
{
    public class Machine
    {
        private readonly DirectionalMapper[] mappers;

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

            var temp = new List<DirectionalMapper>();

            if (plugboard != null)
                temp.Add(new DirectionalMapper(plugboard, Direction.In));

            if (input != null)
                temp.Add(new DirectionalMapper(input, Direction.In));

            foreach(var rotor in rotors.Reverse())
            {
                temp.Add(new DirectionalMapper(rotor, Direction.In));
            }

            if (reflector != null) 
                temp.Add(new DirectionalMapper(reflector.Core, Direction.Reflect));
            
            foreach (var rotor in rotors)
            {
                temp.Add(new DirectionalMapper(rotor, Direction.Out));
            }

            if (input != null)
                temp.Add(new DirectionalMapper(input, Direction.Out));

            if (plugboard != null)
                temp.Add(new DirectionalMapper(plugboard, Direction.Out));

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

            //Move wheels (the wheel on the right always moves)
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

            var currentLetter = inputLetter;

            foreach(var mapper in mappers)
            {
                var currentLetterBefore = currentLetter;

                currentLetter = mapper.Map(currentLetter);

                operations.Add(new InnerOperation(mapper.Source.Name, currentLetterBefore, currentLetter, mapper.Direction));
            }

            return new TypeLetterResult(this, inputLetter, currentLetter, operations.ToArray());     
        }
    }
}