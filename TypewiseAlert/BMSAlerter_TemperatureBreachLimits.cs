using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
       
        //upperlimits for temperature breach among the Cooling Types
        public enum temperatureBreach_UpperLimits
        {
            PASSIVE_COOLING = 35,
            HI_ACTIVE_COOLING = 45,
            MED_ACTIVE_COOLING = 40
        }

        //prone to changes 
        public enum temperatureBreach_LowerLimits
        {
            PASSIVE_COOLING = 0,
            HI_ACTIVE_COOLING = 0,
            MED_ACTIVE_COOLING = 0
        }

        
    }
}