namespace Enigma.Logic
{
    public class Plugboard : CrossConnector
    {
        public Plugboard(CrossConnection[] connections) 
            : base(connections, true)
        {
        }
    }
}