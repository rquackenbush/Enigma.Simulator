namespace Enigma.Logic
{
    public static class AlphabetExtensions
    {
        /// <summary>
        /// Normalizes the index of a rotor to an actual position on the rotor.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int NormalizeIndex(this Alphabet alphabet, int index)
        {
            return index % alphabet.Count;
        }
    }
}
