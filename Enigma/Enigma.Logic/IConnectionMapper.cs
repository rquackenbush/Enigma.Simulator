namespace Enigma.Logic
{
    public interface IConnectionMapper
    {
        string Name { get; }

        int MapForward(int inputIndex);

        int MapReverse(int outputIndex);
    }
}
