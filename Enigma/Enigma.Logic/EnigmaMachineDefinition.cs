namespace Enigma.Logic
{
    /// <summary>
    /// The definition of an enigma machine.
    /// </summary>
    public class EnigmaMachineDefinition
    {
        /// <summary>
        /// The name of this machine.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The alaphabet used by this machine.
        /// </summary>
        public string? Alphabet { get; set; }

        /// <summary>
        /// Available Inputs
        /// </summary>
        public InputDefinition[]? Inputs { get; set; }

        /// <summary>
        /// Available Rotors
        /// </summary>
        public EnigmaRotorDefinition[]? Rotors { get; set; }
    
        /// <summary>
        /// Available Reflectors
        /// </summary>
        public ReflectorDefinition[]? Reflectors { get; set; } 
    }
}
