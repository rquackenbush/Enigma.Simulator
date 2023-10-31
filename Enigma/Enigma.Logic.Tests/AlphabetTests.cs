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
            var alphabet = EnigmaBuilder.BuildAlphabet(letters);

            alphabet.IndexOf(letter).ShouldBe(expectedIndex);
        }

        [Theory]
        [InlineData("abcdef", 2, 'c')]
        public void LetterByIndex(string letters, int index, char expectedVelue)
        {
            var alaphbet = EnigmaBuilder.BuildAlphabet(letters);

            alaphbet[index].Letter.ShouldBe(expectedVelue);
        }

        [Fact]
        public void LetterByIndex2()
        {
            var alphabet = EnigmaBuilder.BuildAlphabet("ABCD");

            alphabet[1].Letter.ShouldBe('B');
        }
    }
}