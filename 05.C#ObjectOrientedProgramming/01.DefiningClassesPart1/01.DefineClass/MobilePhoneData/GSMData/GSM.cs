namespace MobileDeviceCharacteristics.MobilePhoneData.GSMData
{
    using System.Collections.Generic;
    using System.Text;
    using Batteries;
    using CallTest;
    using DisplayData;

    public class GSM : MobilePhone // Inheritated all properties from class MobilePhone.
    {
        // Fields in class GSM.
        private static readonly GSM iPhone6S = new GSM("iPhone6S", "Apple", 1200.00m, "Alexander Alexandrov");
        private static readonly decimal pricePerMinute = 0.25m;
        private List<Call> myTodayCalls = new List<Call>();

        // Properties in class GSM.
        public int CallsCount
        {
            get { return myTodayCalls.Count; }
        }

        public decimal PricePerMinute
        {
            get { return pricePerMinute; }
        }

        // Constructors in class GSM.
        public GSM IPhone6S
        {
            get { return iPhone6S; }
        }

        public GSM(string model = null, string manufacturer = null, decimal price = 0, string owner = null, Battery type = null, Display size = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = type;
            this.Display = size;
        }

        // Methods in class GSM.
        public void AddCall(Call call)
        {
            myTodayCalls.Add(call);
        }

        public void DeleteCall(Call call)
        {
            myTodayCalls.Remove(call);
        }

        public void DeleteCallAtIndex(int index)
        {
            myTodayCalls.RemoveAt(index);
        }

        public void ClearCalls()
        {
            myTodayCalls.Clear();
        }

        public int FindIndexOfLongestDuration(int maxDuration)
        {
            int index = 0;
            for (int i = 0; i < myTodayCalls.Count; i++)
            {
                if (myTodayCalls[i].DurationOfCallInSeconds == maxDuration)
                {
                    index = i;
                }
            }
            return index;
        }

        public int CalculateTotalDuration()
        {
            int totalDurationOfCalls = 0;
            foreach (var call in myTodayCalls)
            {
                totalDurationOfCalls += call.DurationOfCallInSeconds;
            }
            return totalDurationOfCalls;
        }

        public int MaxDuration()
        {
            int maxDuration = 0;
            foreach (var call in myTodayCalls)
            {
                if (call.DurationOfCallInSeconds > maxDuration)
                {
                    maxDuration = call.DurationOfCallInSeconds;
                }
            }
            return maxDuration;
        }

        public decimal CalculateTotalPrice(int totalDuration)
        {
            decimal totalPrice = (totalDuration / 60) * pricePerMinute;
            return totalPrice;
        }

        public override string ToString()
        {
            var phoneInformation = new StringBuilder();
            if (this.Model != null)
            {
                phoneInformation.AppendLine("Model: " + this.Model);
            }
            if (this.Manufacturer != null)
            {
                phoneInformation.AppendLine("Manufacturer: " + this.Manufacturer);
            }
            if (this.Price > 0)
            {
                phoneInformation.AppendLine("Price: " + this.Price + " lv.");
            }
            if (this.Owner != null)
            {
                phoneInformation.AppendLine("Owner " + this.Owner);
            }
            if (this.Battery != null)
            {
                phoneInformation.AppendLine("Battery info:");
                phoneInformation.AppendLine("- " + Battery.Model);
                phoneInformation.AppendLine("- " + Battery.HoursIdle);
                phoneInformation.AppendLine("- " + Battery.HoursTalk);
                phoneInformation.AppendLine("- " + Battery.TypeOfBattery);
            }
            if (this.Display != null)
            {
                phoneInformation.AppendLine("Display info:");
                phoneInformation.AppendLine("- " + Display.DisplaySize);
                phoneInformation.AppendLine("- " + Display.DisplayColorNumbers);
            }
            return phoneInformation.ToString();
        }
    }
}