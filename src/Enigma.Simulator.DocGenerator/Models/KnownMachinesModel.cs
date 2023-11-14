namespace Enigma.Simulator.DocGenerator.Models
{
    public record class KnownMachinesModel(KnownMachineModel[] Machines)
    {
    }

    public record class KnownMachineModel(string Name, string Alphabet, RotorModel[] Rotors)
    {
    }

    public record class RotorModel(string Name, string Wiring, string Notches, string Turnover)
    {
    }
}
