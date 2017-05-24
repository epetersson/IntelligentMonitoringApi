using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMonitoringBackend.Entities
{
    public interface IEvent
    {
        DateTime CreatedTimeStamp { get; set; }

        bool Active { get; set; }

        bool Seen { get; set; }

        string Information { get; set; }

        string EventCategoryName { get; set; }

        string RuleName { get; set; }

        string RuleDescription { get; set; }

        int SeverityLevel { get; set; }

        string TriggerName { get; set; }

        string TriggerOperator { get; set; }

        string DeviceId { get; set; }

        string DeviceName { get; set; }
    }
}
