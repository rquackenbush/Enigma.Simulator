namespace Enigma.Logic.Tests
{
    public class WheelTests
    {
        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 0, 'A', 'B')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 0, 'B', 'D')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 1, 'A', 'P')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 1, 'B', 'C')]
        public void WheelShouldSignalForward(string alphabet, string wiring, char wheelSetting, int ringSetting, char inputLetter, char expectedLetter)
        {
            //Build the Wheel
            var rotor = new Rotor("Test", alphabet, wiring, Array.Empty<int>(), ringSetting, alphabet.IndexOf(wheelSetting));

            //Send a signal through the wheel
            var outputIndex = rotor.SignalForward(alphabet.IndexOf(inputLetter));

            var outputLetter = alphabet[outputIndex];

            outputLetter.ShouldBe(expectedLetter);
        }

        [Theory]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'D', 'A')]
        [InlineData("ABCD", "DCBA", 'A', 'B', 'D', 'B')]
        public void WheelShouldSignalReverse(string alphabet, string wiring, char wheelSetting, char ringSetting, char inputLetter, char expectedLetter)
        {
            //Build the Wheel
            var rotor = new Rotor("Test", alphabet, wiring, Array.Empty<int>(), alphabet.IndexOf(ringSetting), alphabet.IndexOf(wheelSetting));

            //Send a signal through the wheel
            var outputIndex =  rotor.SignalReverse(alphabet.IndexOf(inputLetter));

            var outputLetter = alphabet[outputIndex];

            outputLetter.ShouldBe(expectedLetter);
        }

        [Theory]
        [InlineData("ABCD", 'A', 'B')]
        [InlineData("ABCD", 'D', 'A')]
        public void AdvanceShouldWork(string alphabet, char wheelSetting, char expectedWheelPosition)
        {
            var wheel = new Rotor("Test", alphabet, alphabet, Array.Empty<int>(), 0, alphabet.IndexOf(wheelSetting));

            wheel.Advance();
            wheel.PositionIndex.ShouldBe(alphabet.IndexOf(expectedWheelPosition));           
        }
    }
}
