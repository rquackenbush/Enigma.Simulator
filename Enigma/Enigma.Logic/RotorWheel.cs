namespace Enigma.Logic
{
    public class RotorWheel : WheelBase, IConnectionMapper
    {
        private readonly HashSet<int> notchIndicies;

        public RotorWheel(string name, RotorCore core, int ringSettingIndex, int initialPositionIndex, int[] notchIndicies) 
            : base(name, core, ringSettingIndex, initialPositionIndex)
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

            PositionIndex = (PositionIndex + 1) % Core.Count;

            return notchIndicies.Contains(positionIndexBeforeAdvance);
        }
    }
}