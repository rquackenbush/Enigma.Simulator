namespace Enigma.Simulator
{
    /// <summary>
    /// An Enigma machine configuration.
    /// </summary>
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
        /// Ring Settings in the order of [Right Rotor, Middle Rotor, Left Rotor, Reflector]
        /// </summary>
        public required NumbersOrLetters RingSettings { get; set; }

        /// <summary>
        /// Initial Ring (wheel) Positions in the order of [Right Rotor, Middle Rotor, Left Rotor, Reflector]
        /// </summary>
        public required NumbersOrLetters InitialWheelPositions { get; set; }

        /// <summary>
        /// A plugboard in the space separated format of "AB DZ"
        /// </summary>
        public string? Plugboard { get; set; }
    }
}
