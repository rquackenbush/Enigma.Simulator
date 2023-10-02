namespace Enigma.Logic
{
    public class NumbersOrLetters
    {
        public NumbersOrLetters()
        {
        }

        public NumbersOrLetters(int[] numbers)
        {
            Numbers = numbers;
        }

        public NumbersOrLetters(string letters)
        {
            Letters = letters;
        }

        /// <summary>
        /// The one based numbers of the letters in the associated alphabet.
        /// </summary>
        public int[]? Numbers { get; set; }

        /// <summary>
        /// Unique letters that belong to a given alphabet.
        /// </summary>
        public string? Letters { get; set; }
    }
}
