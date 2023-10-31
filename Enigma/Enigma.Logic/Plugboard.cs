namespace Enigma.Logic
{
    public class Plugboard : CrossConnector
    {
        public Plugboard(string alphabet, string wiring) 
            : base(alphabet, wiring)
        {
        }

        public override string Name => "Plugboard";
    }
}