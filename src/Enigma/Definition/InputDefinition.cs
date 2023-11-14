namespace Enigma.Definition
{
    /// <summary>
    /// Defines an input wheel.
    /// </summary>
    public class InputDefinition
    {
        /// <summary>
        /// Creates an instance of <see cref="InputDefinition"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connections"></param>
        public InputDefinition(string name, string connections)
        {
            Name = name;
            Wiring = connections;
        }

        /// <summary>
        /// The name of this input.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The wiring for this wheel.
        /// </summary>
        public string Wiring { get; set; }
    }
}
