namespace Enigma.Logic
{
    /// <summary>
    /// Represents the cross wired core of a rotor.
    /// </summary>
    public class RotorCore : CrossConnector
    {
        public RotorCore(CrossConnection[] connections) 
            : base(connections, false)
        {
        }
    }
}