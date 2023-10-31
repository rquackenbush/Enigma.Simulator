namespace Enigma.Logic
{
    public static class AlphabetExtensions
    {
        public static int[] GetIndicies(this string alphabet, string letters, int offset = 0)
        {
            var result = new int[letters.Length];

            for (var index = 0; index < result.Length; index++)
            {
                result[index] = (alphabet.IndexOf(letters[index]) + offset).Mod(alphabet.Length);
            }

            return result;
        }
    }
}
