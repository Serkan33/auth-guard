

using Mapster;
using MapsterMapper;

namespace EmployeeApi.Mapper
{
    public class MyMapster : IMapper
    {
        TypeAdapterConfig IMapper.Config => throw new NotImplementedException();

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }

        TypeAdapterBuilder<TSource> IMapper.From<TSource>(TSource source)
        {
            throw new NotImplementedException();
        }

        TDestination IMapper.Map<TDestination>(object source)
        {
            throw new NotImplementedException();
        }

        TDestination IMapper.Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt<TDestination>();
        }

        object IMapper.Map(object source, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }

        object IMapper.Map(object source, object destination, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
}

