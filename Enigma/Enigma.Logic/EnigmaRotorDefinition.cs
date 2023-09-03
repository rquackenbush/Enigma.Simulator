namespace Enigma.Logic
{ 
    public record class EnigmaRotorDefinition(string Name, string Connections, string Notches) 
        : EnigmaInputOrOutputDefinition(Name, Connections)
    {
    }

    public record class EnigmaInputOrOutputDefinition(string Name, string Connections)
    {

    }

    public record class InputDefinition(string Name, string Connections) 
        : EnigmaInputOrOutputDefinition(Name, Connections)
    {
    }

    public record class ReflectorDefinition(string Name, string Connections)
        : EnigmaInputOrOutputDefinition(Name, Connections)
    {
    }
}
