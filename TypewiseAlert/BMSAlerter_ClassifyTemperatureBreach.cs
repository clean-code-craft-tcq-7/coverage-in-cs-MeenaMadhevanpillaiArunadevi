using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public static BreachType inferBreach(double value, double lowerLimit, double upperLimit)
        {
            if (value < lowerLimit)
            {
                return BreachType.TOO_LOW;
            }
            if (value > upperLimit)
            {
                return BreachType.TOO_HIGH;
            }
            return BreachType.NORMAL;
        }

        public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            int lowerLimit = getTemperatureBreachLowerLimit(coolingType);
            int upperLimit = getTemperatureBreachUpperLimit(coolingType);
            return inferBreach(temperatureInC, lowerLimit, upperLimit);
        }

        public static int getTemperatureBreachLowerLimit(CoolingType coolingType)
        {
            return (int)Enum.Parse(typeof(temperatureBreach_LowerLimits), coolingType.ToString());
        }

        public static int getTemperatureBreachUpperLimit(CoolingType coolingType)
        {
            return (int)Enum.Parse(typeof(temperatureBreach_UpperLimits), coolingType.ToString());
        }

    }
}