using System;

namespace Enigma.Simulator
{
    /// <summary>
    /// An enigma machine.
    /// </summary>
    public class Machine
    {
        private readonly DirectionalMapper[] mappers;

        /// <summary>
        /// Creates an instnace of the <see cref="Machine"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alphabet"></param>
        /// <param name="input"></param>
        /// <param name="rotors"></param>
        /// <param name="reflector"></param>
        /// <param name="plugboard"></param>
        /// <exception cref="ArgumentNullException"></exception>
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

            foreach (var rotor in rotors.Reverse())
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

        /// <summary>
        /// The name of this machine.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The alphabet used by this machine.
        /// </summary>
        public string Alphabet { get; }

        /// <summary>
        /// The input used for this machine.
        /// </summary>
        public Wheel? Input { get; }

        /// <summary>
        /// The rotors in this machine.
        /// </summary>
        public Rotor[] Rotors { get; }

        /// <summary>
        /// The reflector used in this machine.
        /// </summary>
        public Wheel Reflector { get; }

        /// <summary>
        /// The plugboard used by this machine.
        /// </summary>
        public Plugboard? Plugboard { get; }

        /// <summary>
        /// Simuates typing a letter.
        /// </summary>
        /// <param name="inputLetter"></param>
        /// <returns></returns>
        public TypeLetterResult TypeLetter(char inputLetter)
        {
            var inputIndex = Alphabet.IndexOf(inputLetter);

            var operations = new List<InnerOperation>(mappers.Length);

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

            foreach (var mapper in mappers)
            {
                var beforeIndex = currentIndex;

                currentIndex = mapper.Map(currentIndex);

                operations.Add(new InnerOperation(mapper.Source.Name, beforeIndex, currentIndex, mapper.Direction));
            }

            return new TypeLetterResult(this, inputIndex, currentIndex, operations.ToArray());
        }
    }
}