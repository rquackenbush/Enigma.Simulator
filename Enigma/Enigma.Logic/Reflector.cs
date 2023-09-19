namespace Enigma.Logic
{
    public class Reflector : WheelBase
    {
        public Reflector(Alphabet alphabet, RotorCore core, int ringSettingIndex) 
            : base(alphabet, core, ringSettingIndex, 0)
        {
        }

        public override int MapReverse(int outputIndex)
        {
            throw new NotSupportedException("Reflectors can't perform a " + nameof(MapReverse) + " operation.");
        }
    }
}