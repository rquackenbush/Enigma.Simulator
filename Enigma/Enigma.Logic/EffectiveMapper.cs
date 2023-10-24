namespace Enigma.Logic
{
    public class EffectiveMapper
    {
        public EffectiveMapper(IConnectionMapper source, Direction direction) 
        {
            Source = source;
            Direction = direction;
        }

        public IConnectionMapper Source { get; }

        public Direction Direction { get; }

        public int Map(int inputIndex)
        {
            switch(Direction)
            {
                case Direction.In:
                case Direction.Reflect:
                    return Source.MapForward(inputIndex);

                case Direction.Out:
                    return Source.MapReverse(inputIndex);

                default:
                    throw new InvalidOperationException($"Unknown direction '{Direction}'");
            }
        }
    }
}
