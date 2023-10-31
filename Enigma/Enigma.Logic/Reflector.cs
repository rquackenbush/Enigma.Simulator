namespace Enigma.Logic
{
    public class Reflector : Wheel
    {
        public Reflector(string name, string alphabet, string wiring, int ringSettingIndex, int initialPositionIndex) 
            : base(name, alphabet, wiring, ringSettingIndex, initialPositionIndex)
        {
        }

        public override int SignalReverse(int n)
        {
            throw new NotSupportedException("Reflectors can't SignalReverse.");
        }
    }
}
