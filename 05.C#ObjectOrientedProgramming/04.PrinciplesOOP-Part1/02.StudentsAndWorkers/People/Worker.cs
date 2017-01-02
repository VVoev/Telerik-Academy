namespace _02.StudentsAndWorkers.People
{
    using AbstractClass;
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
        private const int workDays = 5;
         
        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = hoursDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary must be always larget than zero.");
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0 && value > 12)
                {
                    throw new ArgumentOutOfRangeException("Work hours must be always between 1 and 12.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal amount = this.WeekSalary / (this.WorkHoursPerDay * workDays);
            return amount;
        }

        public override string ToString()
        {
            return base.FullName + $", Amount per hour: {this.MoneyPerHour().ToString("F2")} leva.";
        }
    }
}
