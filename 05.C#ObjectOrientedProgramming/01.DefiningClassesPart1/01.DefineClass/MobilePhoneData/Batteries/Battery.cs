namespace MobileDeviceCharacteristics.MobilePhoneData.Batteries
{
    using System;

    public class Battery
    {
        // Fields in class Battery.
        private string batteryModel;
        private double batteryHoursIdle;
        private double batteryHoursTalk;
        private BatteryType batteryType;

        // Properties in class Battery.
        public string Model
        {
            get { return this.batteryModel; }
            set { this.batteryModel = value; }
        }

        public double HoursIdle
        {
            get { return this.batteryHoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours Idle can't be less than 0!");
                }
                else
                {
                    this.batteryHoursIdle = value;
                }
            }
        }

        public double HoursTalk
        {
            get { return this.batteryHoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours Idle can't be less than 0!");
                }
                else
                {
                    this.batteryHoursTalk = value;
                }
            }
        }

        public BatteryType TypeOfBattery
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        // Constructors in class Battery.
        public Battery(string model)
        {
            this.Model = batteryModel;
        }

        public Battery(string model, double hoursIdle)
        {
            this.Model = batteryModel;
            this.HoursIdle = hoursIdle;
        }

        public Battery(string model, double hoursIdle, double hoursTalk)
        {
            this.Model = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = batteryHoursTalk;
        }

        public Battery(string model, BatteryType type)
        {
            this.Model = batteryModel;
            this.TypeOfBattery = batteryType;
        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.TypeOfBattery = type;
        }
    }
}

