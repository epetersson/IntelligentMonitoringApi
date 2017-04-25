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
            Mapper.CreateMap<DeviceDto, Device>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<Sensor, SensorDto>();
            Mapper.CreateMap<SensorDto, Sensor>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<SensorMeasurement, SensorMeasurementDto>();
            Mapper.CreateMap<SensorMeasurementDto, SensorMeasurement>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<DeviceNetwork, DeviceNetworkDto>();
            Mapper.CreateMap<DeviceNetworkDto, DeviceNetwork>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;

            /*Mapper.CreateMap<History, HistoryDto>();
            Mapper.CreateMap<HistoryDto, History>();*/
        }
    }
}