using Shouldly;

namespace Enigma.Logic.Tests
{
    public class AlphabetTests
    {
        [Theory]
        [InlineData(new char[] { 'a', 'b', 'c', 'd' }, 4)]
        public void CreateAlphabetTests(char[] letters, int expectedLength)
        {
            var alphabet = new Alphabet(letters);

            alphabet.Count.ShouldBe(expectedLength);
        }

        [Theory]
        [InlineData("abcdef", 'c', 2)]
        public void IndexOfTest(string letters, char letter, int expectedIndex)
        {
            var alphabet = MachineBuilder.BuildAlphabet(letters);

            alphabet.IndexOf(letter).ShouldBe(expectedIndex);
        }

        [Theory]
        [InlineData("ABC", 0, 0)]
        [InlineData("ABC", 1, 1)]
        [InlineData("ABC", 2, 2)]
        [InlineData("ABC", 3, 0)]
        [InlineData("ABC", 4, 1)]
        public void NormalizeTest(string letters, int index, int expectedNormalizedIndex)
        {
            var alphabet = MachineBuilder.BuildAlphabet(letters);

            alphabet.NormalizeIndex(index).ShouldBe(expectedNormalizedIndex);
        }
    }
}