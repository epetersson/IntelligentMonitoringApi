using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Device, DeviceDto>();
            Mapper.CreateMap<DeviceDto, Device>();

            Mapper.CreateMap<Sensor, SensorDto>();
            Mapper.CreateMap<SensorDto, Sensor>();

            Mapper.CreateMap<DeviceNetwork, DeviceNetworkDto>();
            Mapper.CreateMap<DeviceNetworkDto, DeviceNetwork>();

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>();
        }
    }
}