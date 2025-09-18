using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo.Utility
{
    public class Mapper
    {
        public static IMapper _mapper;
        public static TDestination Map<TSource, TDestination>(TSource source, Action<IMappingExpression<TSource, TDestination>> memberOptions = null)
        {

            var config = new MapperConfiguration(cfg =>
            {
                var mappingExpression = cfg.CreateMap<TSource, TDestination>();
                memberOptions?.Invoke(mappingExpression);
            }

           ); // 註冊Model間的對映
            _mapper = config.CreateMapper();
            var result = _mapper.Map<TDestination>(source);
            return result;
        }

        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source, Action<IMappingExpression<TSource, TDestination>> memberOptions = null)
        {

            var config = new MapperConfiguration(cfg =>
            {
                var mappingExpression = cfg.CreateMap<TSource, TDestination>();
                memberOptions?.Invoke(mappingExpression);
            }

           ); // 註冊Model間的對映
            _mapper = config.CreateMapper();
            var result = _mapper.Map<IEnumerable<TDestination>>(source);
            return result;
        }

    }
}
