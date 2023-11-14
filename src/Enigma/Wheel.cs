namespace Enigma
{
    /// <summary>
    /// Base class for wheels.
    /// </summary>
    public abstract class Wheel : CrossConnector
    {
        /// <summary>
        /// Creates an instance of the <see cref="Wheel"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        /// <param name="ringSettingIndex"></param>
        /// <param name="initialPositionIndex"></param>
        /// <exception cref="ArgumentException"></exception>
        protected Wheel(string name, string alphabet, string wiring, int ringSettingIndex, int initialPositionIndex) : base(alphabet, wiring)
        {
            if (initialPositionIndex >= alphabet.Length)
                throw new ArgumentException($"initialPositionIndex was {initialPositionIndex} but the alphabet only has {alphabet.Length} letters.");

            Name = name;
            RingSettingIndex = ringSettingIndex;
            PositionIndex = initialPositionIndex;
        }

        /// <summary>
        /// Gets the zero based position of this wheel. For some wheels (such as Input wheels and reflectors) this will never change.
        /// </summary>
        public int PositionIndex { get; protected set; }

        /// <summary>
        /// The zero based ring setting for this wheel.
        /// </summary>
        public int RingSettingIndex { get; }

        /// <summary>
        /// Gets the name of this wheel.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override int SignalForward(int index)
        {
            var effectivePosition = (PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var pin = (index + effectivePosition).Mod(alphabet.Length);

            var contact = forwardMap[pin];

            var result = (contact - effectivePosition).Mod(alphabet.Length);

            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override int SignalReverse(int index)
        {
            var effectivePosition = (PositionIndex - RingSettingIndex).Mod(alphabet.Length);

            var contact = (index + effectivePosition).Mod(alphabet.Length);

            var pin = reverseMap[contact];

            return (pin - effectivePosition).Mod(alphabet.Length);
        }
    }
}