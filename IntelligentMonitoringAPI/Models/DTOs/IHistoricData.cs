using IntelligentMonitoringBackend.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMonitoringBackend.Entities
{
    public interface IHistoricData
    {
        int Id { get; set; }

        string DeviceId { get; set; }

        DateTime CreatedTimeStamp { get; set; }

        decimal AverageSignalStrength { get; set; }

        decimal MaxSignalStrength { get; set; }

        decimal MinSignalStrength { get; set; }

        string SignalMeasurementUnit { get; set; }

        long CollectiveContactLostTime { get; set; }

        int CollectiveContactLostCount { get; set; }

        List<decimal> Readings { get; set; }

        HistoryRangeType DataType { get; set; }

    }
}
