namespace Enigma.Logic
{
    public interface IConnectionMapper
    {
        string Name { get; }

        char MapForward(char inputLetter);

        char MapReverse(char outputLetter);
    }
}
