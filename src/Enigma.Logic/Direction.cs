namespace Enigma.Logic
{
    /// <summary>
    /// The direction for a <see cref="DirectionalMapper"/> instance.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// In, or right-to-left.
        /// </summary>
        In,

        /// <summary>
        /// This is for the reflector. There should be one and only one of these.
        /// </summary>
        Reflect,

        /// <summary>
        /// Our, or left-to-right.
        /// </summary>
        Out
    }
}
