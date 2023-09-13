namespace Enigma.Logic.Definitions
{
    public class MachineDefinition
    {
        public string? Name { get; set; }

        public string? Alphabet { get; set; }

        public int SlotCount { get; set; }

        public InputDefinition[]? Inputs { get; set; }

        public RotorDefinition[]? Rotors { get; set; }

        public ReflectorDefinition[]? Reflectors { get; set; }

        public bool HasPlugBoard { get; set; }
    }
}
