using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {

        public class EmailAlerter : IBreachEmailAlerter
        {
            private bool IsEmailTriggered = false;
            public void sendEmail(BreachType breachType)
            {
                sendToEmail(breachType);
            }
            public bool IsProcesstriggered()
            {
                return IsEmailTriggered;
            }

        }
    }
}
