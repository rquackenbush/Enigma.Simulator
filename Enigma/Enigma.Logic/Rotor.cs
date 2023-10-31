using System.Collections.Immutable;

namespace Enigma.Logic
{
    public class Rotor : Wheel
    {
        private readonly ImmutableArray<int> notchIndicies;

        public Rotor(string name, string alphabet, string wiring, string notches, int ringSettingIndex, int initialPositionIndex) 
            : base(name, alphabet, wiring, ringSettingIndex, initialPositionIndex)
        {
            notchIndicies = notches
              .Select(n => alphabet.IndexOf(n))
              .ToImmutableArray();
        }

        /// <summary>
        /// Returns true of the next wheel is supposed to advance
        /// </summary>
        /// <returns></returns>
        public bool Advance()
        {
            var positionIndexBeforeAdvance = PositionIndex;

            PositionIndex = (PositionIndex + 1).Mod(alphabet.Length);

            return notchIndicies.Contains(positionIndexBeforeAdvance);
        }
    }
}