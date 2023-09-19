namespace Enigma.Logic
{
    /// <summary>
    /// A letter within an alphabet.
    /// </summary>
    /// <param name="Alphabet">The owning <see cref="Alphabet"/> instance.</param>
    /// <param name="Index">The index of the letter within its alphabet.</param>
    /// <param name="Letter">The letter.</param>
    public record class AlphabetLetter(Alphabet Alphabet, int Index, char Letter)
    { 
    }
}