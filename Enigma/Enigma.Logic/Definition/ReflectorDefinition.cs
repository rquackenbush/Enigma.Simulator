namespace Enigma.Logic.Definitions
{
    public class ReflectorDefinition
    { 
        public ReflectorDefinition(string name, string connections, bool hasRingSetting)
        {
            Name = name;
            Wiring = connections;
            HasRingSetting = hasRingSetting;
        }

        public string Name { get; set; }

        public string Wiring { get; set; }

        public bool HasRingSetting { get; set; }
    }
}
