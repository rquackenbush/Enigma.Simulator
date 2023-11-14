namespace Enigma.Simulator
{
    /// <summary>
    /// Wraps a <see cref="CrossConnector"/> object. 
    /// </summary>
    public class DirectionalMapper
    {
        /// <summary>
        /// Creates an instance of the <see cref="DirectionalMapper"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="direction"></param>
        public DirectionalMapper(CrossConnector source, Direction direction)
        {
            Source = source;
            Direction = direction;
        }

        /// <summary>
        /// The wrapped instance.
        /// </summary>
        public CrossConnector Source { get; }

        /// <summary>
        /// The direction to invoke mapping onthis <see cref="CrossConnector"/>.
        /// </summary>
        public Direction Direction { get; }

        /// <summary>
        /// Maps the signal according to the <see cref="Direction"/> of this instance.
        /// </summary>
        /// <param name="inputIndex"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Map(int inputIndex)
        {
            switch (Direction)
            {
                case Direction.In:
                case Direction.Reflect:
                    return Source.SignalForward(inputIndex);

                case Direction.Out:
                    return Source.SignalReverse(inputIndex);

                default:
                    throw new InvalidOperationException($"Unknown direction '{Direction}'");
            }
        }
    }
}
