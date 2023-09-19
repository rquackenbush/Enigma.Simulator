namespace Enigma.Logic
{
    public interface IConnectionMapper
    {
        int MapForward(int inputIndex);

        int MapReverse(int outputIndex);
    }
}
