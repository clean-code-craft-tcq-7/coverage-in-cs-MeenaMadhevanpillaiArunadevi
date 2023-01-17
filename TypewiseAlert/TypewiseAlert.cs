using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TypewiseAlert
{
  public partial class TypewiseAlert
  {

        public static int EmailAlert_Sent = 0;
        public static int ControllerAlert_Sent = 0;
        public static void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC, IBreachControllerAlerter _controllerAlerter = null, IBreachEmailAlerter _emailAlerter = null) 
        {
            EmailAlert_Sent = 0;
            ControllerAlert_Sent = 0;
            BreachType breachType = classifyTemperatureBreach(batteryChar.coolingType, temperatureInC); //non io mtd

            switch(alertTarget) {
                case AlertTarget.TO_CONTROLLER: //mock the alerttarget
                    _controllerAlerter.sendToController(breachType);
                    ControllerAlert_Sent += 1;
                    //sendToController(breachType);
                  break;
                case AlertTarget.TO_EMAIL:
                     _emailAlerter.sendEmail(breachType);
                    EmailAlert_Sent += 1;
                    break;
            }
         }
       
  }
   
}
