using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public interface IBreachControllerAlerter
        {
            void sendToController(BreachType breachType);

        }

        public interface IBreachEmailAlerter
        {
            void sendEmail(BreachType breachType);
        }

    }
}
