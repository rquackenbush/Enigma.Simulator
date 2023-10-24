namespace Enigma.Logic.Tests
{
    public class RotorCoreTests
    {
        [Theory]
        [InlineData("AB", "BA", 'A', 'B')]
        [InlineData("ABCD", "DCBA", 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'D', 'A')]
        public void MapForwardShouldWork(string alphabetDefinition, string connectionDefinitions, char inLetter, char outLetter)
        {
            // Build the alphabet
            var alphabet = EnigmaBuilder.BuildAlphabet(alphabetDefinition);

            // Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", alphabet, connectionDefinitions);

            // Get the index of the input letter
            var inputIndex = alphabet.IndexOf(inLetter);

            // Get the output 
            var outputIndex = rotorCore.MapForward(inputIndex);

            // Check the forward connection
            alphabet[outputIndex].Letter.ShouldBe(outLetter);
        }

        [Theory]
        [InlineData("AB", "BA", 'A', 'B')]
        [InlineData("ABCD", "DCBA", 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'D', 'A')]
        public void MapReverseShouldWork(string alphabetDefinition, string connectionDefinitions, char outLetter, char inLetter)
        {
            // Build the alphabet
            var alphabet = EnigmaBuilder.BuildAlphabet(alphabetDefinition);

            // Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Bar", alphabet, connectionDefinitions);

            // Get the index of the input letter
            var outputIndex = alphabet.IndexOf(outLetter);

            // Do the reverse connection
            var inputIndex = rotorCore.MapReverse(outputIndex);

            // Check it
            alphabet[inputIndex].Letter.ShouldBe(inLetter);
        }
    }
}
