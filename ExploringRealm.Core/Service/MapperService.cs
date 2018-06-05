using System;
using AutoMapper;

namespace ExploringRealm.Core.Service
{
    public class MapperService
    {
        // Constructors
        public MapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.MyModel, Model.MyModelDto>()
                .ForMember(
                    dest => dest.Id,
                    opts => opts.MapFrom(src => src.Id.ToString()))
                .ForMember(
                    dest => dest.SomeDateTicks,
                    opts => opts.MapFrom(src => src.SomeDate.Ticks))
                .ForMember(
                    dest => dest.SomeDouble,
                    opts => opts.MapFrom(src => Convert.ToDouble(src.SomeDecimal)));

                cfg.CreateMap<Model.MyModelDto, Model.MyModel>()
                .ForMember(
                    dest => dest.Id,
                    opts => opts.MapFrom(src => new Guid(src.Id)))
                .ForMember(
                    dest => dest.SomeDate,
                    opts => opts.MapFrom(src => new DateTime(src.SomeDateTicks)))
                .ForMember(
                    dest => dest.SomeDecimal,
                    opts => opts.MapFrom(src => Convert.ToDecimal(src.SomeDouble)));
            });

            Mapper = config.CreateMapper();
        }


        // -----------------------------------------------------------------------------

        // Properties
        public IMapper Mapper { get; private set; }
    }
}