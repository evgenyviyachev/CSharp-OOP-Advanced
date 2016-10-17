namespace TPMS.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDMicroExercises.TirePressureMonitoringSystem;

    [TestClass]
    public class SensorTest
    {
        private Sensor sensor;

        [TestInitialize]
        public void TestInit()
        {
            this.sensor = new Sensor();
        }

        [TestMethod]
        public void PopNextPressurePsiValueShouldWorkCorrectly()
        {
            double pressureTelemetryValue = 20;
            double expectedResult = 36;
            double result = this.sensor.PopNextPressurePsiValue(pressureTelemetryValue);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
