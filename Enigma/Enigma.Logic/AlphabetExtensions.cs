namespace Enigma.Logic
{
    public static class AlphabetExtensions
    {
        public static int[] GetIndicies(this Alphabet alphabet, string letters)
        {
            var result = new int[letters.Length];

            for(var index = 0; index < result.Length; index++)
            {
                result[index] = alphabet.IndexOf(letters[index]);
            }

            return result;
        }
    }
}
