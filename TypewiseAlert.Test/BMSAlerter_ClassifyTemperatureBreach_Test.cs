using System;
using Xunit;
using static TypewiseAlert.TypewiseAlert;

namespace Test
{
    public partial class TypewiseAlertTest
    {
        [Fact]
        public void testInfersBreachAsPerLimits()
        {
            //whole positive values 
            Assert.True(inferBreach(12, 20, 30) == BreachType.TOO_LOW);
            Assert.True(inferBreach(12, 0, 30) == BreachType.NORMAL);
            Assert.True(inferBreach(32, 20, 30) == BreachType.TOO_HIGH);

            //whole negative values
            Assert.True(inferBreach(12, -30, 0) == BreachType.TOO_HIGH);
            Assert.True(inferBreach(-12, -10, 30) == BreachType.TOO_LOW);
            Assert.True(inferBreach(-15, -20, -10) == BreachType.NORMAL);

            //decimal values
            Assert.True(inferBreach(0, 0.5, 35.8) == BreachType.TOO_LOW);
            Assert.True(inferBreach(62.9, 50.3, 81.4) == BreachType.NORMAL);
            Assert.True(inferBreach(52.3, 20, 33.6) == BreachType.TOO_HIGH);

        }

        [Fact]
        public void testClassifyTemperatureBreach()
        {

            //above threshold
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString()) + 1) == BreachType.TOO_HIGH);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString()) + 120) == BreachType.TOO_HIGH);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString()) + 10.7) == BreachType.TOO_HIGH);
            Assert.True(classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString())) == BreachType.TOO_HIGH);
            Assert.True(classifyTemperatureBreach(CoolingType.PASSIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString())) == BreachType.TOO_HIGH);
            Assert.True(classifyTemperatureBreach(CoolingType.PASSIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.MED_ACTIVE_COOLING.ToString())) == BreachType.TOO_HIGH);

            //below threshold
            Assert.True(classifyTemperatureBreach(CoolingType.PASSIVE_COOLING,-1) == BreachType.TOO_LOW);
            Assert.True(classifyTemperatureBreach(CoolingType.PASSIVE_COOLING,-50) == BreachType.TOO_LOW);
            Assert.True(classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,-1) == BreachType.TOO_LOW);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,-1) == BreachType.TOO_LOW);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,-10.2) == BreachType.TOO_LOW);

            //threshold
            Assert.True(classifyTemperatureBreach(CoolingType.PASSIVE_COOLING, (int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.PASSIVE_COOLING.ToString())) == BreachType.NORMAL);
            Assert.True(classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.MED_ACTIVE_COOLING.ToString())) == BreachType.NORMAL);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.HI_ACTIVE_COOLING.ToString())) == BreachType.NORMAL);

            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.MED_ACTIVE_COOLING.ToString())) == BreachType.NORMAL);
            Assert.True(classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, (int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.PASSIVE_COOLING.ToString())) == BreachType.NORMAL);
            Assert.True(classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,(int)Enum.Parse(typeof(temperatureBreach_UpperLimits), CoolingType.PASSIVE_COOLING.ToString())) == BreachType.NORMAL);
            Assert.True(classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,2) == BreachType.NORMAL);


        }

        [Fact]
        public void testGetTemperatureBreachLowerLimit()
        {
            //Test the lower and upper limits of Temperature Breach
            Assert.True(getTemperatureBreachLowerLimit(CoolingType.HI_ACTIVE_COOLING) == 0);
            Assert.True(getTemperatureBreachLowerLimit(CoolingType.MED_ACTIVE_COOLING) == 0);
            Assert.True(getTemperatureBreachLowerLimit(CoolingType.PASSIVE_COOLING) == 0);

            Assert.True(getTemperatureBreachUpperLimit(CoolingType.HI_ACTIVE_COOLING) == 45);
            Assert.True(getTemperatureBreachUpperLimit(CoolingType.MED_ACTIVE_COOLING) == 40);
            Assert.True(getTemperatureBreachUpperLimit(CoolingType.PASSIVE_COOLING) == 35);

        }

    }
}