namespace Enigma.Simulator
{
    /// <summary>
    /// The result of typing a single letter on an <see cref="Enigma"/> machine instance.
    /// </summary>
    /// <param name="Machine"></param>
    /// <param name="InputIndex"></param>
    /// <param name="OutputIndex"></param>
    /// <param name="Operations"></param>
    public record class TypeLetterResult(Machine Machine, int InputIndex, int OutputIndex, InnerOperation[] Operations)
    {
    }
}
