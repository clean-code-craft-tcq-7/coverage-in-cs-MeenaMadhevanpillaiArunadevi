using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public static void sendToController(BreachType breachType) 
        {
          
                const ushort header = 0xfeed;
                Console.WriteLine(string.Format("{0} : {1}", header, breachType));
             
        }
        public static void sendToEmail(BreachType breachType)
        {          
                string recepient = "a.b@c.com";

                int isEmailAlert_Sent = 0;
                if (breachType != BreachType.NORMAL)
                {
                    Console.WriteLine(string.Format("To: {0}", recepient));
                    Console.WriteLine(JsonConvert.SerializeObject(breachType, new StringEnumConverter()));
                    isEmailAlert_Sent += 1; //mail sent
                }
                //mail not sent as normal
           
        }
    }
}