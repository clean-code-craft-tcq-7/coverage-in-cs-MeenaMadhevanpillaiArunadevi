using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public static int sendToController(BreachType breachType)
        {
            try
            {
                const ushort header = 0xfeed;
                Console.WriteLine(string.Format("{0} : {1}", header, breachType));
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }
        public static int sendToEmail(BreachType breachType)
        {
            try
            {
                string recepient = "a.b@c.com";
                if (breachType != BreachType.NORMAL)
                {
                    Console.WriteLine(string.Format("To: {0}", recepient));
                    Console.WriteLine(JsonConvert.SerializeObject(breachType, new StringEnumConverter()));
                    return 1; //mail sent
                }
                return 2;//mail not sent as normal
            }
            catch(Exception ex)
            {
                return 0; //failure in mail
            }
            
            
        }
    }
}