namespace Omnitudo.API.Mappers
{
    public abstract class Mapper<TSource, TTarget>
    {
        public abstract TSource ToSource(TTarget target);

        public abstract TTarget ToTarget(TSource source);

        public IEnumerable<TSource> ToSource(IEnumerable<TTarget> targets)
        {
            return targets.Select(t => ToSource(t));
        }

        public IEnumerable<TTarget> ToTarget(IEnumerable<TSource> sources)
        {
            return sources.Select(t => ToTarget(t));
        }
    }
}
