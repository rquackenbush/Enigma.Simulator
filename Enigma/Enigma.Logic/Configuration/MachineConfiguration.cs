namespace Enigma.Logic.Configuration
{
    public class MachineConfiguration
    {
        /// <summary>
        /// The name of the ETW
        /// </summary>
        public required string InputName { get; set; }

        public required string[] WheelOrder { get; set; }

        public required string ReflectorName { get; set; }

        public required int[] RingPositions { get; set; }

        public string? Plugboard { get; set; }
    }
}
