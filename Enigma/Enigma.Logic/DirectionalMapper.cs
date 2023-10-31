namespace Enigma.Logic
{
    public class DirectionalMapper
    {
        public DirectionalMapper(IConnectionMapper source, Direction direction) 
        {
            Source = source;
            Direction = direction;
        }

        public IConnectionMapper Source { get; }

        public Direction Direction { get; }

        public char Map(char inputLetter)
        {
            switch (Direction)
            {
                case Direction.In:
                case Direction.Reflect:
                    return Source.MapForward(inputLetter);

                case Direction.Out:
                    return Source.MapReverse(inputLetter);

                default:
                    throw new InvalidOperationException($"Unknown direction '{Direction}'");
            }
        }
    }
}
