using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {

        public class ControllerAlerter
        {
            private IBreachControllerAlerter _breachControllerAlerter;
            public ControllerAlerter(IBreachControllerAlerter breachControllerAlerter)
            {
                _breachControllerAlerter = breachControllerAlerter;
            }
            public void notifySendToController(BreachType breachType)
            {

                _breachControllerAlerter.sendToController(breachType);
            }
        }
        //Mocking Controller Alert - creating a dummy object that represents a real object we want to test
        public class MockControllerAlerter : IBreachControllerAlerter
        {
            public int isControllerAlert_Sent = 0;
            public void sendToController(BreachType breachType)
            {
                isControllerAlert_Sent += 1;

            }
        }

    }
}
