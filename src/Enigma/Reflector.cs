namespace Enigma
{
    /// <summary>
    /// Represents the left most wheel on the machine. This wheel does not turn, but might have a ring setting.
    /// </summary>
    public class Reflector : Wheel
    {
        /// <summary>
        /// Creates an instance o the <see cref="Reflector"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        /// <param name="ringSettingIndex"></param>
        /// <param name="initialPositionIndex"></param>
        public Reflector(string name, string alphabet, string wiring, int ringSettingIndex, int initialPositionIndex)
            : base(name, alphabet, wiring, ringSettingIndex, initialPositionIndex)
        {
        }

        /// <summary>
        /// Not supported by a reflector.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override int SignalReverse(int n)
        {
            throw new NotSupportedException("Reflectors can't SignalReverse.");
        }
    }
}
