namespace Enigma
{
    /// <summary>
    /// Validates various Enigma aspects.
    /// </summary>
    public static class EnigmaValidator
    {
        /// <summary>
        /// Validates that all letters appear at most once int he specified string.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="EnigmaValidationException"></exception>
        private static void ValidateAllLettersAreUnique(this string value)
        {
            var letters = new HashSet<char>();

            foreach (var letter in value)
            {
                if (letters.Contains(letter))
                    throw new EnigmaValidationException($"The letter '{letter}' appears more than once in '{value}'.");
            }
        }

        /// <summary>
        /// Validates that an alphabet is valid.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <exception cref="EnigmaValidationException"></exception>
        public static void ValidateAlphabet(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
                throw new EnigmaValidationException("Alphabet was null or empty.");

            if (alphabet.Length == 0)
                throw new EnigmaValidationException("Alphabet has to have at least one character");

            alphabet.ValidateAllLettersAreUnique();
        }

        /// <summary>
        /// Validates that every letter in the alphabet has a wiring entry and that no connections are repeated.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        /// <exception cref="EnigmaValidationException"></exception>
        public static void ValidateWiring(string alphabet, string wiring)
        {
            if (wiring.Length != alphabet.Length)
                throw new EnigmaValidationException($"Alphabet had {alphabet.Length} but there were {wiring.Length} connections in the wiring.");

            wiring.ValidateAllLettersAreUnique();

            var alphabetHashSet = alphabet.ToHashSet();

            if (wiring.Any(l => !alphabetHashSet.Contains(l)))
                throw new EnigmaValidationException();
        }
    }
}