namespace Enigma.Logic
{
    public class Reflector : WheelBase
    {
        public Reflector(string name, RotorCore core, int ringSettingIndex, int initialWheelPositionIndex) 
            : base(name, core, ringSettingIndex, initialWheelPositionIndex)
        {
        }

        public override int MapReverse(int outputIndex)
        {
            throw new NotSupportedException("Reflectors can't perform a " + nameof(MapReverse) + " operation.");
        }
    }
}