namespace Enigma.Logic.Configuration
{
    public class MachineConfiguration
    {
        /// <summary>
        /// The name of the ETW
        /// </summary>
        public string? InputName { get; set; }

        /// <summary>
        /// In the case of ["I", "II", "III"], "III" is the right most wheel.
        /// </summary>
        public required string[] WheelOrder { get; set; }

        /// <summary>
        /// The name of the UKW
        /// </summary>
        public required string ReflectorName { get; set; }

        /// <summary>
        /// One based position of the ring setting
        /// </summary>
        public required int[] RingSettings{ get; set; }

        /// <summary>
        /// The initial position of the rings.
        /// </summary>
        public required string RingPositions { get; set; }

        public string? Plugboard { get; set; }
    }
}
