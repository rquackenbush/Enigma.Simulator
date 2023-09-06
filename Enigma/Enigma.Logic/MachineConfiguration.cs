namespace Enigma.Logic
{
    public class MachineConfiguration
    {
        public string MachineName { get; set; }

        /// <summary>
        /// The name of the ETW
        /// </summary>
        public string InputName { get; set; }

        public RotorConfiguration[] Rotors { get; set; }

        public ReflectorConfiguration Reflector { get; set; }

        public string Plugboard { get; set; }
    }

    public class RotorConfiguration
    {
        public string RotorName { get; set; }

        public char RingSetting { get; set; }

        public char InitialPosition { get; set; }
    }

    public class ReflectorConfiguration
    {
        public string ReflectorName { get; set; }

        public char RingSetting { get; set; }
    }
}
