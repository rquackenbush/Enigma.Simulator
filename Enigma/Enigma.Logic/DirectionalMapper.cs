namespace Enigma.Logic
{
    public class DirectionalMapper
    {
        public DirectionalMapper(CrossConnector source, Direction direction) 
        {
            Source = source;
            Direction = direction;
        }

        public CrossConnector Source { get; }

        public Direction Direction { get; }

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
