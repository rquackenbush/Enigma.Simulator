namespace Enigma.Logic.Definitions
{
    public class RotorDefinition
    {
        public RotorDefinition(string name, string connections, string notches)
        {
            Name = name;
            Connections = connections;
            Notches = notches;
        }

        public string Name { get; set; }

        public string Connections { get; set; }

        public string Notches { get; set; }
    }
}
