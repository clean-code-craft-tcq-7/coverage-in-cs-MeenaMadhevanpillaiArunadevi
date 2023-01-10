using System;
using Xunit;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Test
{
  public partial class TypewiseAlertTest
  {
        BatteryCharacter batteryCharacter = new BatteryCharacter();
        [Fact]
        public void testingCheckAndAlert()
        {
            batteryCharacter.coolingType = CoolingType.HI_ACTIVE_COOLING;
            //If Mail/message to Controller sent = 1; If Mail not Sent since NORMAL = 2 ; If Failure = 0
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 0) == 2); //normal - no email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 41) == 2);//normal - no email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 101) == 1);//high value - email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, -4) == 1);//low value - email

            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, 106) == 1);
            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, -5) == 1);

            batteryCharacter.coolingType = CoolingType.MED_ACTIVE_COOLING;

            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 42) == 1);//high - email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, -7) == 1);//low value - email

            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, 105) ==1);
            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, -3) == 1);


            batteryCharacter.coolingType = CoolingType.PASSIVE_COOLING;

            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 0) == 2); //normal - no email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, 100) == 1);//high value - email
            Assert.True(checkAndAlert(AlertTarget.TO_EMAIL, batteryCharacter, -9) == 1);//low value - email

            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, 105) == 1);
            Assert.True(checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, -6) == 1);

        }

        [Fact]
        public void testingSendToController()
        {
            Assert.True(sendToController(BreachType.TOO_LOW) == 1);
            Assert.True(sendToController(BreachType.TOO_HIGH) == 1);
            Assert.True(sendToController(BreachType.NORMAL) == 1);
        }

        [Fact]
        public void testingSendToEmail()
        {
            Assert.True(sendToEmail(BreachType.TOO_LOW) == 1);
            Assert.True(sendToEmail(BreachType.TOO_HIGH) == 1);
            Assert.True(sendToEmail(BreachType.NORMAL) == 2);
        }
    }
}
