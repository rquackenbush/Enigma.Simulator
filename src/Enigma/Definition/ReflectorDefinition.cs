namespace Enigma.Definition
{
    /// <summary>
    /// Defines a reflector
    /// </summary>
    public class ReflectorDefinition
    {
        /// <summary>
        /// Creates an instance of the <see cref="ReflectorDefinition"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connections"></param>
        /// <param name="hasRingSetting"></param>
        public ReflectorDefinition(string name, string connections, bool hasRingSetting)
        {
            Name = name;
            Wiring = connections;
            HasRingSetting = hasRingSetting;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the wiring used in this reflector.
        /// </summary>
        public string Wiring { get; set; }

        /// <summary>
        /// Flag Indiciating whether this reflector supports a ring setting.
        /// </summary>
        public bool HasRingSetting { get; set; }
    }
}
