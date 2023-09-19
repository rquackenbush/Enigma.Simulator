namespace Enigma.Logic
{
    public class RotorWheel : WheelBase
    {
        private readonly HashSet<int> notchIndicies;

        public RotorWheel(Alphabet alphabet, RotorCore core, int ringSettingIndex, int initialPositionIndex, int[] notchIndicies) 
            : base(alphabet, core, ringSettingIndex, initialPositionIndex)
        {
            this.notchIndicies = notchIndicies.ToHashSet();
        }

        /// <summary>
        /// Advance the rotor to the next position.
        /// </summary>
        /// <returns>True if the initial position is on a notch, false otherwise.</returns>
        public bool Advance()
        {
            var positionIndexBeforeAdvance = PositionIndex;

            PositionIndex = Alphabet.NormalizeIndex(PositionIndex + 1);

            return notchIndicies.Contains(positionIndexBeforeAdvance);
        }
    }
}