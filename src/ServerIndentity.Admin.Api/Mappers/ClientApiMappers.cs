﻿using AutoMapper;

namespace ServerIndentity.Admin.Api.Mappers
{
    public static class ClientApiMappers
    {
        static ClientApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientApiMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
        
        public static T ToClientApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}







