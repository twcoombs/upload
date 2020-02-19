using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using upload.Dtos;
using upload.Models;

namespace upload.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<SubmissionPoint, SubmissionPointDto>();
            Mapper.CreateMap<SubmissionPointDto, SubmissionPoint>();
            Mapper.CreateMap<Collection, CollectionDto>();
            Mapper.CreateMap<CollectionDto, Collection>();
            Mapper.CreateMap<CollectionPoint, CollectionPointDto>();
            Mapper.CreateMap<CollectionPointDto, CollectionPoint>();
            Mapper.CreateMap<PointType, PointTypeDto>();
            Mapper.CreateMap<PointTypeDto, PointType>();
        }

    }
}