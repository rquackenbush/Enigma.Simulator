namespace Enigma.Definition
{
    /// <summary>
    /// The definition of a rotor
    /// </summary>
    public class RotorDefinition
    {
        /// <summary>
        /// Creates an instance of the <see cref="RotorDefinition"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connections"></param>
        /// <param name="notches"></param>
        public RotorDefinition(string name, string connections, string notches)
        {
            Name = name;
            Wiring = connections;
            Notches = notches;
        }

        /// <summary>
        /// Gets the name of this <see cref="RotorDefinition"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the wiring configuration of this <see cref="RotorDefinition"/>.
        /// </summary>
        public string Wiring { get; set; }

        /// <summary>
        /// Gets the notches that this wheel supports.`
        /// </summary>
        public string Notches { get; set; }
    }
}
