using System.Collections.Immutable;

namespace Enigma.Logic
{
    /// <summary>
    /// The letters which make up an alphabet.
    /// </summary>
    public class EnigmaAlphabet
    {
        private readonly ImmutableDictionary<char, EnigmaLetter> letterLookup;

        public EnigmaAlphabet(char[] letters)
        {
            var lettersArray = letters
                .Select((l, i) => new EnigmaLetter(this, i, l))
                .ToArray();

            Letters = ImmutableArray.CreateRange(lettersArray);
            letterLookup = lettersArray
                .ToImmutableDictionary<EnigmaLetter, char, EnigmaLetter>(l => l.Letter, l => l);
        }

        /// <summary>
        /// The letters in the alphabet for this enigma machine.
        /// </summary>
        public ImmutableArray<EnigmaLetter> Letters { get; }

        /// <summary>
        /// Gets the index of a given letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public int IndexOf(char letter)
        {
            if (!letterLookup.TryGetValue(letter, out var enigmaLetter))
                throw new InvalidOperationException($"Unable to find the letter '{letter}' in the alphabet.");

            return enigmaLetter.Index;
        }

        /// <summary>
        /// Gets an <see cref="EnigmaLetter"/> given its character.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public EnigmaLetter this[char letter] => letterLookup[letter];

        public EnigmaLetter this[int index] => Letters[index];

        /// <summary>
        /// Gets the number of letters in the alphabet.
        /// </summary>
        public int Count => Letters.Length;
    }
}