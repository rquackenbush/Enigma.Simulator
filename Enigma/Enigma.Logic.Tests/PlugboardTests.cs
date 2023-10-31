namespace Enigma.Logic.Tests
{
    public class PlugboardTests
    {
        [Theory]
        [InlineData("ABCD")]
        [InlineData("ABCDEFGHIJK")]
        public void EmptyPlugboardShouldWork(string alphabet)
        {
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            var plugboard = EnigmaBuilder.BuildPlugboard(builtAlphabet, "");

            plugboard.ShouldNotBeNull();

            foreach(var letter in alphabet)
            {
                plugboard.MapForward(letter).ShouldBe(letter);
                plugboard.MapReverse(letter).ShouldBe(letter);
            }
        }

        [Theory]
        [InlineData("ABCD", "AB", 'A', 'B')]
        [InlineData("ABCD", "AB", 'C', 'C')]
        public void ConfguredPlugboardShouldMapForward(string alphabet, string connections, char inputLetter, char expectedOutputLetter)
        {
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            var plugboard = EnigmaBuilder.BuildPlugboard(builtAlphabet, connections);

            plugboard.ShouldNotBeNull();

            plugboard.MapForward(inputLetter).ShouldBe(expectedOutputLetter);

        }
    }
}
