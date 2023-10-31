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

        public override int SignalForward(int index)
        {
            var effectivePosition = (PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var pin = (index + effectivePosition).Mod(alphabet.Length);

            var contact = forwardMap[pin];

            var result = (contact - effectivePosition).Mod(alphabet.Length);

            return result;
        }

        public override int SignalReverse(int index)
        {
            var effectivePosition = (PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var contact = (index + effectivePosition).Mod(alphabet.Length);

            var pin = reverseMap[contact];

            return (pin - effectivePosition).Mod(alphabet.Length);
        }
    }
}