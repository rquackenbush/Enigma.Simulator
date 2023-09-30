﻿namespace Enigma.Logic
{
    /// <summary>
    /// Base class for Input Wheels, Reflectors and Rotors.
    /// </summary>
    public abstract class WheelBase
    { 
        public WheelBase(RotorCore core, int ringSettingIndex, int initialPositionIndex)
        {
            Core = core ?? throw new ArgumentNullException(nameof(core));
            RingSettingIndex = ringSettingIndex;
            PositionIndex = initialPositionIndex;
        }

        public RotorCore Core { get; }

        public int RingSettingIndex { get; }

        public int PositionIndex { get; protected set; }

        public int MapForward(int inputIndex)
        {
            var effectiveCoreIndex = (PositionIndex + RingSettingIndex + inputIndex) % Core.Count;

            return Core.MapForward(effectiveCoreIndex);
        }

        public virtual int MapReverse(int outputIndex)
        {
            var effectiveCoreIndex = (PositionIndex + RingSettingIndex + outputIndex) % Core.Count;

            return Core.MapReverse(effectiveCoreIndex);
        }
    }
}