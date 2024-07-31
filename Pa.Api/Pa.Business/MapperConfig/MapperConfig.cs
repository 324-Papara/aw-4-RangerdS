using AutoMapper;
using Pa.Data.Domain;
using Pa.Schema.Factory;
using Pa.Schema.FactoryDetail;
using Pa.Schema.FactoryLocation;
using Pa.Schema.FactoryPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Factory, FactoryResponse>();
            CreateMap<FactoryRequest, Factory>();

            CreateMap<FactoryDetail, FactoryDetailResponse>();
            CreateMap<FactoryDetailRequest, FactoryDetail>();

            CreateMap<FactoryLocation, FactoryLocationResponse>();
            CreateMap<FactoryLocationRequest, FactoryLocation>();

            CreateMap<FactoryPhone, FactoryPhoneResponse>();
            CreateMap<FactoryPhoneRequest, FactoryPhone>();

        }
    }
}
