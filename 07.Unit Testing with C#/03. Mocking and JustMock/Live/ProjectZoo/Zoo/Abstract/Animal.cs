using System.Collections.Generic;

namespace Zoo.Abstract
{
    public abstract class Animal
    {
        private NextId id;
       public NextId ID { get; set; }

       public string Name { get; protected set; }

        public int Age { get; protected set; }

        public virtual string Hello()
        {
            return this.Name + "Say Hello";
        }

        public Animal(string name,int age)
        {
            this.Name = name;
            this.Age= age;

        }




    }
}
