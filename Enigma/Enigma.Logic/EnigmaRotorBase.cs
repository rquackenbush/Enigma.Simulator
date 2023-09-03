namespace Enigma.Logic
{
    public abstract class EnigmaRotorBase
    {
        protected EnigmaRotorBase(string name, EnigmaRotorPosition[] positions)
        {
            Name = name;
            Positions = positions;
        }

        /// <summary>
        /// Gets the name of this rotor.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The positions in this rotor.
        /// </summary>
        public EnigmaRotorPosition[] Positions { get; }

        /// <summary>
        /// Map to an output index.
        /// </summary>
        /// <param name="inputIndex"></param>
        /// <returns></returns>
        public int Map(int inputIndex)
        {
            return Positions[inputIndex].OutputIndex;
        }
    }
}