namespace Enigma.Logic.Tests
{
    public class WheelTests
    {
        [Theory]
        //[InlineData("ABCD", "DCBA", 'A', 'A', 'A', 'D')]
        //[InlineData("ABCD", "DCBA", 'A', 'B', 'A', 'C')]
        //[InlineData("ABCD", "DCBA", 'A', 'A', 'B', 'C')]
        //[InlineData("ABCD", "ABCD", 'B', 'A', 'A', 'B')]

        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 0, 'A', 'B')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 0, 'B', 'D')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 1, 'A', 'P')]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A', 1, 'B', 'C')]
        public void WheelShouldSignalForward(string alphabet, string wiring, char wheelSetting, int ringSetting, char inputLetter, char expectedLetter)
        {
            //Build the Wheel
            var rotor = new Rotor("Test", alphabet, wiring, "", ringSetting, alphabet.IndexOf(wheelSetting));

            //Send a signal through the wheel
            var outputIndex = rotor.SignalForward(alphabet.IndexOf(inputLetter));

            var outputLetter = alphabet[outputIndex];

            outputLetter.ShouldBe(expectedLetter);
        }

        [Theory]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'D', 'A')]
        [InlineData("ABCD", "DCBA", 'A', 'B', 'D', 'B')]
        //[InlineData("ABCD", "DCBA", 'A', 'A', 'B', 'C')]
        //[InlineData("ABCD", "ABCD", 'B', 'A', 'B', 'A')]
        public void WheelShouldSignalReverse(string alphabet, string wiring, char wheelSetting, char ringSetting, char inputLetter, char expectedLetter)
        {
            //Build the Wheel
            var rotor = new Rotor("Test", alphabet, wiring, "", alphabet.IndexOf(ringSetting), alphabet.IndexOf(wheelSetting));

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
            var wheel = new Rotor("Test", alphabet, alphabet, "", 0, alphabet.IndexOf(wheelSetting));

            wheel.Advance();
            wheel.PositionIndex.ShouldBe(alphabet.IndexOf(expectedWheelPosition));           
        }
    }
}
