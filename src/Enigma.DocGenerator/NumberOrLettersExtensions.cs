using Enigma.Logic;

namespace Enigma.DocGenerator
{
    internal static class NumberOrLettersExtensions
    {
        internal static string ToLetters(this NumbersOrLetters numberOrLetters, string alphabet)
        {
            var indicies = numberOrLetters.ToInidicies(alphabet);

            return string.Join("", indicies.Select(i => alphabet[i]));
        }
    }
}
