using System;

namespace Enigma.Logic
{
    public class Machine
    {
        private readonly DirectionalMapper[] mappers;

        public Machine(string name, string alphabet, InputWheel? input, Rotor[] rotors, Reflector reflector, Plugboard? plugboard)
        {
            Name = name;
            EnigmaValidator.ValidateAlphabet(alphabet);
            Alphabet = alphabet; ;
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

            //Reflector
            temp.Add(new DirectionalMapper(reflector, Direction.Reflect));
            
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

        public string Alphabet { get; }

        public Wheel? Input { get; }

        public Rotor[] Rotors { get; }

        public Wheel Reflector { get; }

        public Plugboard? Plugboard { get; }

        public TypeLetterResult TypeLetter(char inputLetter)
        {
            var inputIndex = Alphabet.IndexOf(inputLetter);

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

            var currentIndex = inputIndex;

            foreach(var mapper in mappers)
            {
                var beforeIndex = currentIndex;

                currentIndex = mapper.Map(currentIndex);

                operations.Add(new InnerOperation(mapper.Source.Name, beforeIndex, currentIndex, mapper.Direction));
            }

            return new TypeLetterResult(this, inputIndex, currentIndex, operations.ToArray());     
        }
    }
}