namespace Enigma.Logic.Tests
{
    public class RotorCoreTests
    {
        [Theory]
        [InlineData("AB", "BA", 'A', 'B')]
        [InlineData("ABCD", "DCBA", 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'D', 'A')]
        public void MapForwardShouldWork(string alphabetDefinition, string connectionDefinitions, char inputLetter, char expectedLetter)
        {
            // Build the alphabet
            var alphabet = EnigmaBuilder.BuildAlphabet(alphabetDefinition);

            // Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Foo", alphabet, connectionDefinitions);

            rotorCore.MapForward(inputLetter).ShouldBe(expectedLetter);
        }

        [Theory]
        [InlineData("AB", "BA", 'A', 'B')]
        [InlineData("ABCD", "DCBA", 'A', 'D')]
        [InlineData("ABCD", "DCBA", 'D', 'A')]
        public void MapReverseShouldWork(string alphabetDefinition, string connectionDefinitions, char inputLetter, char expectedLetter)
        {
            // Build the alphabet
            var alphabet = EnigmaBuilder.BuildAlphabet(alphabetDefinition);

            // Build the rotorcore
            var rotorCore = EnigmaBuilder.BuildRotorCore("Bar", alphabet, connectionDefinitions);

            rotorCore.MapReverse(inputLetter).ShouldBe(expectedLetter);
        }
    }
}
