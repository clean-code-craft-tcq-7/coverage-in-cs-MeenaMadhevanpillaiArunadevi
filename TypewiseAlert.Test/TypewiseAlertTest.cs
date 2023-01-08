using System;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(TypewiseAlert.inferBreach(12, 20, 30) ==
        TypewiseAlert.BreachType.TOO_LOW);

    }

        [Fact]
        public void InfersBreachAsPerLimits1()
        {
            Assert.True(TypewiseAlert.inferBreach(12, 20, 30) ==
              TypewiseAlert.BreachType.TOO_LOW);

        }
    }
}
