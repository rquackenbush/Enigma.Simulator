namespace Enigma.Logic
{
    public class InputWheel : WheelBase, IConnectionMapper
    {
        public InputWheel(string name, RotorCore core) 
            : base(name, core, 0, 0)
        {
        }
    }
}