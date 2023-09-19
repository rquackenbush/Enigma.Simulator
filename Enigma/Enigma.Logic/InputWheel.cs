namespace Enigma.Logic
{
    public class InputWheel : WheelBase, IConnectionMapper
    {
        public InputWheel(RotorCore core) 
            : base(core, 0, 0)
        {
        }
    }
}