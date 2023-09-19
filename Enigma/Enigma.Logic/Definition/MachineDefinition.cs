namespace Enigma.Logic.Definitions
{
    public class MachineDefinition
    {
        public required string Name { get; set; }

        public required string Alphabet { get; set; }

        public required int SlotCount { get; set; }

        public required InputDefinition[] Inputs { get; set; }

        public required RotorDefinition[] Rotors { get; set; }

        public required ReflectorDefinition[] Reflectors { get; set; }

        public required bool HasPlugBoard { get; set; }
    }
}
