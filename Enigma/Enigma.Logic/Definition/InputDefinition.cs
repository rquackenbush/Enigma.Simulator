namespace Enigma.Logic.Definitions
{
    public class InputDefinition
    {
        public InputDefinition() { }

        public InputDefinition(string? name, string? connections)
        {
            Name = name;
            Connections = connections;
        }

        public string? Name { get; set; }

        public string? Connections { get; set; }
    }
}
