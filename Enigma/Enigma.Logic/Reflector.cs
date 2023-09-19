namespace Enigma.Logic
{
    public class Reflector : WheelBase
    {
        public Reflector(RotorCore core, int ringSettingIndex) 
            : base(core, ringSettingIndex, 0)
        {
        }

        public override int MapReverse(int outputIndex)
        {
            throw new NotSupportedException("Reflectors can't perform a " + nameof(MapReverse) + " operation.");
        }
    }
}