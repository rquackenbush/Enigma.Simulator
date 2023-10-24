namespace Enigma.Logic.Tests
{
    public class WheelTests
    {
        [Theory]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'A', 'B', 'A', 'C')]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'B', 'C')]
        public void WheelTestShouldBe(string alphabet, string connections, char wheelSetting, char ringSetting, char inputChar, char expectedOutputLetter)
        {
            //Build the alphabet
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            //Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", builtAlphabet, connections);

            //Get the offsets
            var ringSettingIndex = alphabet.IndexOf(ringSetting);
            var initialPositionIndex = alphabet.IndexOf(wheelSetting);

            //Build the wheel
            var wheel = new RotorWheel("", rotorCore, ringSettingIndex, initialPositionIndex, new int[] { 0 });

            //Send a signal through the wheel
            var outputIndex = wheel.MapForward(alphabet.IndexOf(inputChar));

            //Make sure it connected to what we thought it should connect to.
            alphabet[outputIndex].ShouldBe(expectedOutputLetter);
        }
    }
}
