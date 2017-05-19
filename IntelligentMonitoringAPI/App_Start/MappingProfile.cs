using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;
using IntelligentMonitoringBackend.ModelsDTO;

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

            Mapper.CreateMap<SensorMeasurement, SensorMeasurementDto>();
            Mapper.CreateMap<SensorMeasurementDto, SensorMeasurement>();

            Mapper.CreateMap<DeviceNetwork, DeviceNetworkDto>();
            Mapper.CreateMap<DeviceNetworkDto, DeviceNetwork>();

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>();

            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();

            Mapper.CreateMap<CustomEvent, CustomEventDto>();
            Mapper.CreateMap<CustomEventDto, CustomEvent>();

            Mapper.CreateMap<LocationResource, LocationResourceDto>();
            Mapper.CreateMap<LocationResourceDto, LocationResource>();

            Mapper.CreateMap<DeviceHistory, DeviceHistoryDto>();
            Mapper.CreateMap<DeviceHistoryDto, DeviceHistory>();

            Mapper.CreateMap<DailyStatistic, DailyStatisticDto>();
            Mapper.CreateMap<DailyStatisticDto, DailyStatistic>();

            Mapper.CreateMap<Position, PositionDto>();
            Mapper.CreateMap<PositionDto, Position>();
        }
    }
}