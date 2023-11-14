namespace Enigma
{
    /// <summary>
    /// Reprents the inner workings of an Enigma crypt operation.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="InputIndex"></param>
    /// <param name="OutputIndex"></param>
    /// <param name="Direction"></param>
    public record class InnerOperation(string Name, int InputIndex, int OutputIndex, Direction Direction)
    {
    }
}