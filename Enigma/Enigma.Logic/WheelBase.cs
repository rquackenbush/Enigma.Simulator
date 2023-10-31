namespace Enigma.Logic
{
    /// <summary>
    /// Base class for Input Wheels, Reflectors and Rotors.
    /// </summary>
    public abstract class WheelBase
    {
        private readonly Alphabet alphabet;

        public WheelBase(Alphabet alphabet, string name, RotorCore core, int ringSettingIndex, int initialWheelPositionIndex)
        {
            this.alphabet = alphabet;
            Name = name;
            Core = core ?? throw new ArgumentNullException(nameof(core));
            RingSettingIndex = ringSettingIndex;
            PositionIndex = initialWheelPositionIndex;
        }

        public string Name { get; }

        public RotorCore Core { get; }

        public int RingSettingIndex { get; }

        public int PositionIndex { get; protected set; }

        public char MapForward(char inputLetter)
        {
            var inputLetterIndex = alphabet.IndexOf(inputLetter);

            var letter = Core.
            
            return Core.MapForward(coreLetter);
        }

        public virtual char MapReverse(char outputLetter)
        {

            throw new NotImplementedException();

            //var effectiveCoreIndex = (PositionIndex + RingSettingIndex + outputIndex) % Core.Count;

            //return Core.MapReverse(effectiveCoreIndex);
        }
    }
}