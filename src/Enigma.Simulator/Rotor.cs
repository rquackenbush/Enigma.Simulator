using System.Collections.Immutable;

namespace Enigma.Simulator
{
    /// <summary>
    /// Represents a wheel that is automatically turned (advanced) when a letter is pressed.
    /// </summary>
    public class Rotor : Wheel
    {
        private readonly ImmutableArray<int> notchIndicies;

        /// <summary>
        /// Creates a new instance of the <see cref="Rotor"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alphabet"></param>
        /// <param name="wiring"></param>
        /// <param name="notchIndicies"></param>
        /// <param name="ringSettingIndex"></param>
        /// <param name="initialPositionIndex"></param>
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