namespace Enigma.Definition
{
    /// <summary>
    /// Defines an Engima machine and its capabilities.
    /// </summary>
    public class MachineDefinition
    {
        /// <summary>
        /// Gets the name of the <see cref="MachineDefinition"/>.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The alphabet used in this machine and all of its components.
        /// </summary>
        public required string Alphabet { get; set; }

        /// <summary>
        /// The number of rotor wheel slots.
        /// </summary>
        public required int SlotCount { get; set; }

        /// <summary>
        /// The available input wheels.
        /// </summary>
        public required InputDefinition[] Inputs { get; set; }

        /// <summary>
        /// The available rotor wheels.
        /// </summary>
        public required RotorDefinition[] Rotors { get; set; }

        /// <summary>
        /// The available reflector wheels.
        /// </summary>
        public required ReflectorDefinition[] Reflectors { get; set; }

        /// <summary>
        /// Flag indicating the presences of a PlugBoard on this machine.
        /// </summary>
        public required bool HasPlugBoard { get; set; }
    }
}
