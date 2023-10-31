namespace Enigma.Logic.Tests
{
    public class WheelTests
    {
        [Theory]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'A', 'B', 'A', 'C')]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'B', 'C')]
        [InlineData("ABCD", "ABCD", 'B', 'A', 'A', 'B')]
        public void WheelShouldMapForward(string alphabet, string connections, char wheelSetting, char ringSetting, char inputLetter, char expectedLetter)
        {
            //Build the alphabet
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            //Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", builtAlphabet, connections);

            //Get the offsets
            var ringSettingIndex = builtAlphabet.IndexOf(ringSetting);
            var initialPositionIndex = builtAlphabet.IndexOf(wheelSetting);

            //Build the wheel
            var wheel = new RotorWheel(builtAlphabet, "", rotorCore, ringSettingIndex, initialPositionIndex, new int[] { });

            //Send a signal through the wheel
            wheel.MapForward(inputLetter).ShouldBe(expectedLetter);
        }

        [Theory]
        [InlineData("ABCD", "DCBA", 'A', 'A', 'D', 'A')]
        [InlineData("ABCD", "DCBA", 'A', 'B', 'D', 'D')]
        //[InlineData("ABCD", "DCBA", 'A', 'A', 'B', 'C')]
        //[InlineData("ABCD", "ABCD", 'B', 'A', 'B', 'A')]
        public void WheelShouldMapReverse(string alphabet, string connections, char wheelSetting, char ringSetting, char inputLetter, char expectedOutputLetter)
        {
            //Build the alphabet
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            //Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", builtAlphabet, connections);

            //Get the offsets
            var ringSettingIndex = builtAlphabet.IndexOf(ringSetting);
            var initialPositionIndex = builtAlphabet.IndexOf(wheelSetting);

            //Build the wheel
            var wheel = new RotorWheel(builtAlphabet, "", rotorCore, ringSettingIndex, initialPositionIndex, new int[] { });

            //Send a signal through the wheel
            wheel.MapReverse(inputLetter).ShouldBe(expectedOutputLetter);
        }

        [Theory]
        [InlineData("ABCD", 'A', 'B')]
        [InlineData("ABCD", 'D', 'A')]
        public void AdvanceShouldWork(string alphabet, char wheelSetting, char expectedWheelPosition)
        {
           var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            var ringSettingIndex = 0;
            var initialPositionIndex = builtAlphabet.IndexOf(wheelSetting);

            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", builtAlphabet, alphabet);

            var wheel = new RotorWheel(builtAlphabet, "", rotorCore, ringSettingIndex, initialPositionIndex, new int[] { });

            wheel.Advance();
            wheel.PositionIndex.ShouldBe(builtAlphabet[expectedWheelPosition].Index);           
        }
    }
}
