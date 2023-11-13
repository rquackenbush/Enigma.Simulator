namespace Enigma.Logic
{
    /// <summary>
    /// Math useful for Enigma operations.
    /// </summary>
    public static class EnigmaMath
    {
        /// <summary>
        /// The built in % operator doesn't handle negative inputs in the way that we would like. This fixes that problem.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int Mod(this int x, int m)
        {
            int r = x % m;

            return r < 0 ? r + m : r;
        }
    }
}
