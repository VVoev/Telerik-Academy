namespace _02.HumanCreator
{
    public class Human
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public static Human MakeHuman(int age)
        {
            Human human = new Human();
            human.Age = age;
            if (age % 2 == 0)
            {
                human.Name = "Michael";
                human.Sex = Sex.HotMale;
            }
            else
            {
                human.Name = "Michaela";
                human.Sex = Sex.SexyChick;
            }

            return human;
        }

        public override string ToString()
        {
            return $@"Hello i am {this.Name} with age {this.Age} and my gender is {this.Sex}";
        }
    }
}
