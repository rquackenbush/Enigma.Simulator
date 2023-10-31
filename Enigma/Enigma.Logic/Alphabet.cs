using System.Collections;
using System.Collections.Immutable;

namespace Enigma.Logic
{
    /// <summary>
    /// The letters which make up an alphabet.
    /// </summary>
    public class Alphabet : IEnumerable<AlphabetLetter>
    {
        private readonly ImmutableDictionary<char, AlphabetLetter> letterLookup;

        public Alphabet(char[] letters)
        {
            var lettersArray = letters
                .Select((l, i) => new AlphabetLetter(this, i, l))
                .ToArray();

            Letters = ImmutableArray.CreateRange(lettersArray);
            letterLookup = lettersArray
                .ToImmutableDictionary(l => l.Letter, l => l);
        }

        /// <summary>
        /// The letters in the alphabet for this enigma machine.
        /// </summary>
        public ImmutableArray<AlphabetLetter> Letters { get; }

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
        /// Gets an <see cref="AlphabetLetter"/> given its character.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public AlphabetLetter this[char letter] => letterLookup[letter];

        /// <summary>
        /// Gets an <see cref="AlphabetLetter"/> given its index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AlphabetLetter this[int index] => Letters[index];

        /// <summary>
        /// Gets the number of letters in the alphabet.
        /// </summary>
        public int Count => Letters.Length;

        public IEnumerator<AlphabetLetter> GetEnumerator()
        {
            return letterLookup.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return letterLookup.Values.GetEnumerator();
        }
    }
}