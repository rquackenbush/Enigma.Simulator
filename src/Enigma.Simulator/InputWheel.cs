namespace Enigma.Simulator
{
    /// <summary>
    /// Represents an input wheel.
    /// </summary>
    public class InputWheel : Wheel
    {
        /// <summary>
        /// Creates an instance of the <see cref="InputWheel"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        public InputWheel(string name, string alphabet, string wiring)
            : base(name, alphabet, wiring, 0, 0)
        {
        }
    }
}