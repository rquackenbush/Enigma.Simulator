namespace Enigma.Logic.Definitions
{
    public class ReflectorDefinition
    {
        public ReflectorDefinition() { }

        public ReflectorDefinition(string name, string connections, bool hasRingSetting)
        {
            Name = name;
            Connections = connections;
            HasRingSetting = hasRingSetting;
        }

        public string? Name { get; set; }

        public string? Connections { get; set; }

        public bool HasRingSetting { get; set; }
    }
}
