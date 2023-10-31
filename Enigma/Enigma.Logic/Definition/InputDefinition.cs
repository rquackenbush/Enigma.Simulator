namespace Enigma.Logic.Definitions
{
    public class InputDefinition
    {
        public InputDefinition(string name, string connections)
        {
            Name = name;
            Wiring = connections;
        }

        public string Name { get; set; }

        public string Wiring { get; set; }
    }
}
