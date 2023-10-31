namespace Enigma.Logic
{
    public class Reflector : WheelBase
    {
        public Reflector(Alphabet alphabet, string name, RotorCore core, int ringSettingIndex, int initialWheelPositionIndex) 
            : base(alphabet, name, core, ringSettingIndex, initialWheelPositionIndex)
        {
        }

        public override char MapReverse(char outputLetter)
        {
            throw new NotSupportedException("Reflectors can't perform a " + nameof(MapReverse) + " operation.");
        }
    }
}