using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {

        public class ControllerAlerter: IBreachControllerAlerter
        {
             public void sendToController(BreachType breachType)
            {

                const ushort header = 0xfeed;
                Console.WriteLine(string.Format("{0} : {1}", header, breachType));
            }
        }
       

    }
}
