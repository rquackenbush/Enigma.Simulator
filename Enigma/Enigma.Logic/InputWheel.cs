namespace Enigma.Logic
{
    public class InputWheel : WheelBase, IConnectionMapper
    {
        public InputWheel(Alphabet alphabet, string name, RotorCore core) 
            : base(alphabet, name, core, 0, 0)
        {
        }
    }
}