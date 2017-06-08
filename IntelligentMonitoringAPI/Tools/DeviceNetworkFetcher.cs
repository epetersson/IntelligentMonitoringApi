using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelligentMonitoringAPI.Models;

namespace IntelligentMonitoringAPI.Tools
{
    /// <summary>
    /// Class in charge of retrieving the appropiate 
    /// device network.
    /// </summary>
    public class DeviceNetworkFetcher
    {
        /// <summary>
        /// Attempts to retrieve the appropiate device network based 
        /// on the used token.
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="authorization"></param>
        /// <returns></returns>
        internal static DeviceNetwork FetchNetwork(IntelliMonDbContext _context, AuthorizationToken authorization)
        {
            DeviceNetwork deviceNetwork = null;

            if (authorization != null)
            {
                if (!String.IsNullOrEmpty(authorization.Token))
                {
                    deviceNetwork = _context.DeviceNetworks.Where(obj => String.Compare(obj.AuthToken, authorization.Token) == 0).FirstOrDefault();
                }
                else
                {
                    deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
                }
            }
            else
            {
                deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
            }

            return deviceNetwork;
        }
    }
}