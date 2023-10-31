namespace Enigma.Logic
{
    public class Wheel : CrossConnector
    {
        public Wheel(string name, string alphabet, string wiring, int ringSettingIndex, int initialPositionIndex) : base(alphabet, wiring)
        {
            if (initialPositionIndex >= alphabet.Length)
                throw new ArgumentException($"initialPositionIndex was {initialPositionIndex} but the alphabet only has {alphabet.Length} letters.");

            Name = name;
            RingSettingIndex = ringSettingIndex;
            PositionIndex = initialPositionIndex;
        }

        public int PositionIndex { get; protected set; }

        public int RingSettingIndex { get; }

        public override string Name { get; }

        public override int SignalForward(int n)
        {
            var effectivePosition = (this.PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var pin = (n + effectivePosition).Mod(alphabet.Length);

            var contact = forwardMap[pin];

            var result = (contact - effectivePosition).Mod(alphabet.Length);

            return result;
        }

        public override int SignalReverse(int n)
        {
            var effectivePosition = (this.PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var contact = (n + effectivePosition).Mod(alphabet.Length);

            var pin = reverseMap[contact];

            return (pin - effectivePosition).Mod(alphabet.Length);
        }
    }
}