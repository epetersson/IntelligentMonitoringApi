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
            Mapper.CreateMap<Device, SimpleDeviceDto>();
            Mapper.CreateMap<SimpleDeviceDto, Device>();

            Mapper.CreateMap<Sensor, SensorDto>();
            Mapper.CreateMap<SensorDto, Sensor>();
            Mapper.CreateMap<Sensor, DeviceSensorDto>();
            Mapper.CreateMap<DeviceSensorDto, Sensor>();

            Mapper.CreateMap<SensorMeasurement, SensorMeasurementDto>();
            Mapper.CreateMap<SensorMeasurementDto, SensorMeasurement>();

            Mapper.CreateMap<DeviceNetwork, DeviceNetworkDto>();
            Mapper.CreateMap<DeviceNetworkDto, DeviceNetwork>();
            Mapper.CreateMap<DeviceNetwork, SimpleDeviceNetworkDto>();
            Mapper.CreateMap<SimpleDeviceNetworkDto, DeviceNetwork>();

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>();
            Mapper.CreateMap<Location, SimpleLocationDto>();
            Mapper.CreateMap<SimpleLocationDto, Location>();

            Mapper.CreateMap<History, HistoryDto>();
            Mapper.CreateMap<HistoryDto, History>();
        }
    }
}