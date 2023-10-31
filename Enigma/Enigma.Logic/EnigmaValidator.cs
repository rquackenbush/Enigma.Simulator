namespace Enigma.Logic
{
    public static class EnigmaValidator
    {
        private static void ValidateAllLettersAreUnique(this string value)
        {
            var letters = new HashSet<char>();

            foreach(var letter in value)
            {
                if (letters.Contains(letter))
                    throw new EnigmaValidationException($"The letter '{letter}' appears more than once in '{value}'.");
            }
        }

        public static void ValidateAlphabet(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
                throw new EnigmaValidationException("Alphabet was null or empty.");

            if (alphabet.Length == 0)
                throw new EnigmaValidationException("Alphabet has to have at least one character");

            alphabet.ValidateAllLettersAreUnique();
        }

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