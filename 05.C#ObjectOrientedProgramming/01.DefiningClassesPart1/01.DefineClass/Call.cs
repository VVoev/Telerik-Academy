namespace MobileDeviceCharacteristics
{
    using System;

    public class Call
    {
        // Fields in class Call.
        private DateTime dateOfCall;
        private string callerPhoneNumber;
        private int callDuration;

        // Properties in class Call.
        public DateTime DateAndTimeOfCall
        {
            get { return this.dateOfCall; }
            set { this.dateOfCall = value; }
        }
        public string CallerPhoneNumber
        {
            get { return this.callerPhoneNumber; }
            set { this.callerPhoneNumber = value; }
        }
        public int DurationOfCallInSeconds
        {
            get { return this.callDuration; }
            set { this.callDuration = value; }
        }

        // Constructor in class Call.
        public Call(DateTime dateOfCall, string callerPhoneNumber, int callDuration)
        {
            this.DateAndTimeOfCall = dateOfCall;
            this.CallerPhoneNumber = callerPhoneNumber;
            this.DurationOfCallInSeconds = callDuration;
        }
    }
}
