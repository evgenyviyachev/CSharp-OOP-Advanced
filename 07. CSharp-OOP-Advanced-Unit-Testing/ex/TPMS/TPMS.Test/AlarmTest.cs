namespace TPMS.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDMicroExercises.TirePressureMonitoringSystem;

    [TestClass]
    public class AlarmTest
    {
        private Alarm alarm;

        [TestInitialize]
        public void TestInit()
        {
            this.alarm = new Alarm();
        }

        [TestMethod]
        public void CheckShouldTurnAlarmOnWhenBelowLow()
        {
            alarm.Check(0.5);
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void SecondCheckShouldTurnAlarmOff()
        {
            this.CheckShouldTurnAlarmOnWhenBelowLow();
            alarm.Check(2);
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void ThirdCheckShouldTurnAlarmOnWhenOverHigh()
        {
            this.CheckShouldTurnAlarmOnWhenBelowLow();
            this.SecondCheckShouldTurnAlarmOff();
            alarm.Check(10);
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}
