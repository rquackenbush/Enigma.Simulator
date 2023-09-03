namespace Enigma.Logic
{
    /// <summary>
    /// EKW
    /// </summary>
    public class EnigmaInput : EnigmaRotorBase
    {
        public EnigmaInput(string name, EnigmaRotorPosition[] positions)
            : base(name, positions)
        {
        }

        public int MapReverse(int value)
        {
            throw new NotImplementedException();
        }
    }
}