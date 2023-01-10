using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TypewiseAlert
{
  public partial class TypewiseAlert
  {
            
        public static int checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC) {
            int isAlertSuccess = 0;
            BreachType breachType = classifyTemperatureBreach(batteryChar.coolingType, temperatureInC);

            switch(alertTarget) {
                case AlertTarget.TO_CONTROLLER:
                    isAlertSuccess = sendToController(breachType);
                  break;
                case AlertTarget.TO_EMAIL:
                    isAlertSuccess = sendToEmail(breachType);
                  break;
            }
            return isAlertSuccess;
         }
       
  }
}
