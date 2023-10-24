namespace Enigma.Logic
{
    /// <summary>
    /// Represents the cross wired core of a rotor.
    /// </summary>
    public class RotorCore : CrossConnector
    {
        public RotorCore(string name, CrossConnection[] connections) 
            : base(connections, true)
        {
            Name = name;
        }

        public override string Name { get; }
    }
}