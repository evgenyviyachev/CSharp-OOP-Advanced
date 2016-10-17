namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor _sensor = new Sensor();

        private bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public void Check(double pressureTelemetryValue)
        {
            double sensorOffset = 16;
            double psiPressureValue = pressureTelemetryValue + sensorOffset;

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
            else
            {
                _alarmOn = false;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
