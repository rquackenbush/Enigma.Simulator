using System.Collections.Immutable;

namespace Enigma.Logic
{
    public class Rotor : Wheel
    {
        private readonly ImmutableArray<int> notchIndicies;

        public Rotor(string name, string alphabet, string wiring, int[] notchIndicies, int ringSettingIndex, int initialPositionIndex) 
            : base(name, alphabet, wiring, ringSettingIndex, initialPositionIndex)
        {
            this.notchIndicies = notchIndicies
                .Select(i => (i + EnigmaConstants.NotchOffset).Mod(alphabet.Length))
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