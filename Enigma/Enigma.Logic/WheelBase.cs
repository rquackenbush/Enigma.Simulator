namespace Enigma.Logic
{
    /// <summary>
    /// Base class for Input Wheels, Reflectors and Rotors.
    /// </summary>
    public abstract class WheelBase
    { 
        public WheelBase(Alphabet alphabet, RotorCore core, int ringSettingIndex, int initialPositionIndex)
        {
            Alphabet = alphabet;
            Core = core ?? throw new ArgumentNullException(nameof(core));
            RingSettingIndex = ringSettingIndex;
            PositionIndex = initialPositionIndex;
        }

        public Alphabet Alphabet { get; }

        public RotorCore Core { get; }

        public int RingSettingIndex { get; }

        public int PositionIndex { get; protected set; }

        protected int GetEffectiveCoreIndex()
        {
            return Alphabet.NormalizeIndex(PositionIndex + RingSettingIndex);
        }

        public int MapForward(int inputIndex)
        {
            var effectiveCoreIndex = GetEffectiveCoreIndex();

            return Core.MapForward(effectiveCoreIndex);
        }

        public virtual int MapReverse(int outputIndex)
        {
            var effectiveCoreIndex = GetEffectiveCoreIndex();

            return Core.MapReverse(effectiveCoreIndex);
        }
    }
}