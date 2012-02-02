#region

using System.Collections.Generic;
using AutoMapper;

#endregion

namespace ronin.Reflection
{
    public static class TypeMappingHelper<TSource, TDestination>
    {
        public static void CreateMap()
        {
            Mapper.CreateMap<TSource, TDestination>();
        }

        public static TDestination MapType(TSource destination)
        {
            CreateMap();
            return Mapper.Map<TSource, TDestination>(destination);
        }

        public static IEnumerable<TDestination> MapType(IEnumerable<TSource> domains)
        {
            CreateMap();
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(domains);
        }
    }
}