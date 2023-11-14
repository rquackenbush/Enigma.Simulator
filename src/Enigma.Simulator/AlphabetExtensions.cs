namespace Enigma.Simulator
{
    /// <summary>
    /// Helpful methods for interacting with Alphabets.
    /// </summary>
    public static class AlphabetExtensions
    {
        /// <summary>
        /// Returns the indcidies of the letters provided. Note that -1 will be returned for any letter that isn't found.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="letters"></param>
        /// <returns></returns>
        public static int[] GetIndicies(this string alphabet, string letters)
        {
            var result = new int[letters.Length];

            for (var index = 0; index < result.Length; index++)
            {
                result[index] = alphabet.IndexOf(letters[index]);
            }

            return result;
        }
    }
}
