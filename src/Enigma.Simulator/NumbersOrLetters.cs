namespace Enigma.Simulator
{
    /// <summary>
    /// Allows either ring settings or wheel positions to be specified as letters or one based numbers.
    /// </summary>
    /// <remarks>
    /// Some documentation specifies this as letters, others as numbers. This class allows them to be specified as either (but not both!)
    /// </remarks>
    public class NumbersOrLetters
    {
        /// <summary>
        /// Creates an instance of the <see cref="NumbersOrLetters"/> class using one based numbers.
        /// </summary>
        /// <param name="numbers"></param>
        public NumbersOrLetters(int[] numbers)
        {
            Numbers = numbers;
        }

        /// <summary>
        /// Creates an instance of the <see cref="NumbersOrLetters"/> class using letters.
        /// </summary>
        /// <param name="letters"></param>
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
