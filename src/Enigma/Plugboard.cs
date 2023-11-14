namespace Enigma
{
    /// <summary>
    /// Represents a plugboard.
    /// </summary>
    public class Plugboard : CrossConnector
    {
        /// <summary>
        /// Creates an instance of the <see cref="Plugboard"/> class.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        public Plugboard(string alphabet, string wiring)
            : base(alphabet, wiring)
        {
        }

        /// <summary>
        /// Gets the name of the plugboard.
        /// </summary>
        public override string Name => "Plugboard";
    }
}