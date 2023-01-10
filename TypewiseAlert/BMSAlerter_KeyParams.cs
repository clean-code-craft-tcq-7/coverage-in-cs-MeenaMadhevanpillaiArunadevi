using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public enum BreachType
        {
            NORMAL,
            [EnumMember(Value = "Hi, the temperature is too low")]
            TOO_LOW,
            [EnumMember(Value = "Hi, the temperature is too high")]
            TOO_HIGH
        };

        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };
       
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL
        };
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
        }
    }
}