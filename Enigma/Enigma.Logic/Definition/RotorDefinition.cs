namespace Enigma.Logic.Definitions
{
    public class RotorDefinition
    {
        public RotorDefinition(string name, string connections, string notches)
        {
            Name = name;
            Wiring = connections;
            Notches = notches;
        }

        public string Name { get; set; }

        public string Wiring { get; set; }

        public string Notches { get; set; }
    }
}
