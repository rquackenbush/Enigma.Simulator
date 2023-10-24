namespace Enigma.Logic
{
    public class Reflector : WheelBase
    {
        public Reflector(string name, RotorCore core, int ringSettingIndex) 
            : base(name, core, ringSettingIndex, 0)
        {
        }

        public override int MapReverse(int outputIndex)
        {
            throw new NotSupportedException("Reflectors can't perform a " + nameof(MapReverse) + " operation.");
        }
    }
}