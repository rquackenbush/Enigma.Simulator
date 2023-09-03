namespace Enigma.Logic
{
    public class EnigmaMachineInstanceDefinition
    {
        public EnigmaMachine? Machine { get; set; }

        public string? InputName { get; set; }

        public string[]? RotorNames { get; set; }

        public string? ReflectorName { get; set; }

        /// <summary>
        /// The one based indidcies of the rotors
        /// </summary>
        public int[]? InitialRotorPositions { get; set; }
    }
}
