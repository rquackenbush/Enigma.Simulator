namespace Enigma.Logic.Tests
{
    public class PlugboardTests
    {
        [Theory]
        [InlineData("ABCD")]
        [InlineData("ABCDEFGHIJK")]
        public void EmptyPlugboardShouldWork(string alphabet)
        {
            var plugboard = EnigmaBuilder.BuildPlugboard(alphabet, "");

            plugboard.ShouldNotBeNull();

            for(int index = 0; index < alphabet.Length; index++)
            {
                plugboard.SignalForward(index).ShouldBe(index);
                plugboard.SignalReverse(index).ShouldBe(index);
            }
        }

        [Theory]
        [InlineData("ABCD", "AB", 'A', 'B')]
        [InlineData("ABCD", "AB", 'C', 'C')]
        public void ConfguredPlugboardShouldMapForward(string alphabet, string wiring, char inputLetter, char expectedOutputLetter)
        {
            var plugboard = EnigmaBuilder.BuildPlugboard(alphabet, wiring);

            plugboard.ShouldNotBeNull();

            var inputLetterIndex = alphabet.IndexOf(inputLetter);

            inputLetterIndex.ShouldBeGreaterThanOrEqualTo(0);

            var expectedOutputLetterIndex = alphabet.IndexOf(expectedOutputLetter);

            plugboard.SignalForward(inputLetterIndex).ShouldBe(expectedOutputLetterIndex);

        }
    }
}
