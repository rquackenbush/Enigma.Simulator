//using Shouldly;

//namespace Enigma.Logic.Tests
//{
//    public class AlphabetTests
//    {
//        [Theory]
//        [InlineData(new char[] { 'a', 'b', 'c', 'd' }, 4)]
//        public void CreateAlphabetTests(char[] letters, int expectedLength)
//        {
//            var alphabet = new Alphabet(letters);

//            alphabet.Count.ShouldBe(expectedLength);
//        }

//        [Theory]
//        [InlineData("abcdef", 'c', 2)]
//        public void IndexOfTest(string letters, char letter, int expectedIndex)
//        {
//            var alphabet = EnigmaBuilder.BuildAlphabet(letters);

//            alphabet.IndexOf(letter).ShouldBe(expectedIndex);

//        }
//    }
//}