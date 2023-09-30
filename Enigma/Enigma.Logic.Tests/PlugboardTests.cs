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

            for(var index = 0; index < builtAlphabet.Count; index++)
            {
                plugboard.MapForward(index).ShouldBe(index);
                plugboard.MapReverse(index).ShouldBe(index);
            }
        }

        [Theory]
        [InlineData("ABCD", "AB", 'A', 'B')]
        [InlineData("ABCD", "AB", 'C', 'C')]
        public void ConfguredPlugboardShouldMapForward(string alphabet, string connections, char inputLetter, char expectedOutputLetter)
        {
            var builtAlphabet = EnigmaBuilder.BuildAlphabet(alphabet);

            var plugboard = EnigmaBuilder.BuildPlugboard(builtAlphabet, connections);

            plugboard.MapForward(alphabet.IndexOf(inputLetter)).ShouldBe(alphabet.IndexOf(expectedOutputLetter));

        }
    }
}
