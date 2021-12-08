using AutoMapper;
using PBL6BackEnd.DTO;
using PBL6BackEnd.DTO.MaskPredictDTO;
using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Services
{
    public static class MapperService
    {
        private static readonly MapperConfiguration config = new(CreateMap);
        private static readonly IMapper mapper = config.CreateMapper();

        private static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserCreateForm, User>();
            cfg.CreateMap<MaskPredictForm, MaskPredictedInfo>();
            cfg.CreateMap<MaskPredictedInfo, MaskPredictItem>();
            cfg.CreateMap<UserUpdateForm, User>();
        }

        public static T ConvertTo<T>(this object source)
        {
            if (source == null)
            {
                throw new NullReferenceException();
            }

            return mapper.Map<T>(source);
        }

        public static void CopyTo(this object source, object destination)
        {
            if (source == null)
            {
                throw new NullReferenceException("Source can't be null");
            }
            if (destination == null)
            {
                throw new NullReferenceException("Destination can't be null");
            }
            mapper.Map(source, destination);
        }
    }
}
