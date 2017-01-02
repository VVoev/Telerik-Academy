namespace MobileDeviceCharacteristics.MobilePhoneData.CallTest
{
    using System;
    using System.Collections.Generic;
    using Batteries;
    using DisplayData;
    using GSMData;

    public class CallHistoryTest
    {
        public static void CallHistory()
        {
            // Add single GSM.
            Battery niMh = new Battery("Nickel-Cadmium", 8, 3.5, BatteryType.NiMH);
            Display largeDisplay = new Display(5.9, 16000000);
            GSM myCurrentPhone = new GSM("HTC-H1", "HTC", 650, "Andrei Andreev", niMh, largeDisplay);
            List<Call> myCalls = new List<Call>();

            // Add fisrt daily call.
            Call currentCallForToday = new Call(DateTime.Now.AddHours(3), "0888112233", 66);
            myCurrentPhone.AddCall(currentCallForToday);
            myCalls.Add(currentCallForToday);

            // Add second daily call.
            currentCallForToday = new Call(DateTime.Today.AddHours(10), "0999334455", 1222);
            myCurrentPhone.AddCall(currentCallForToday);
            myCalls.Add(currentCallForToday);

            // Add last daily call.
            currentCallForToday = new Call(DateTime.Today.AddHours(8), "0666889922", 2288);
            myCurrentPhone.AddCall(currentCallForToday);
            myCalls.Add(currentCallForToday);

            Console.WriteLine("Call history test information.");
            foreach (var call in myCalls)
            {
                Console.Write("Date: " + call.DateAndTimeOfCall);
                Console.Write(" Phone number: " + call.CallerPhoneNumber);
                Console.Write(" Duration: " + call.DurationOfCallInSeconds);
                Console.WriteLine();
            }

            // Display my phone information.
            Console.WriteLine("My mobile phone characteristics:");
            Console.WriteLine(myCurrentPhone.ToString());

            Console.WriteLine("-----------------------");
            Console.WriteLine("Statistics");

            // Get total duration of calls and calculate total price. Price per minute is set in class GSM to be 0.25 lv.
            int totalDuration = myCurrentPhone.CalculateTotalDuration();
            Console.WriteLine("Total Price: " + myCurrentPhone.CalculateTotalPrice(totalDuration) + " leva.");

            // Get longest duration of call.
            Console.WriteLine("The longest duration: " + myCurrentPhone.MaxDuration() + " seconds.");
            int maxDuration = myCurrentPhone.MaxDuration();
            int longestDurationIndex = myCurrentPhone.FindIndexOfLongestDuration(maxDuration);
            myCurrentPhone.DeleteCallAtIndex(longestDurationIndex);

            totalDuration = myCurrentPhone.CalculateTotalDuration();
            Console.WriteLine("Total Price after removing longest call: " + myCurrentPhone.CalculateTotalPrice(totalDuration) + " leva.");

            myCurrentPhone.ClearCalls();
            if (myCurrentPhone.CallsCount == 0)
            {
                Console.WriteLine("Your calls have been deleted successfully.");
            }
        }
    }
}
