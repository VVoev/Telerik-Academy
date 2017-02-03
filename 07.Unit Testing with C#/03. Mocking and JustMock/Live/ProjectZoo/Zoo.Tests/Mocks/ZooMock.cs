using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Abstract;
using Zoo.Contracts;
using Zoo.Models;

namespace Zoo.Tests.Mocks
{
        public abstract  class ZooMock 
    {

        protected ICollection<Animal> fakeZoo;
        public IZoo ZooData { get; protected set; }


        private void PopulateData()
        {
            this.fakeZoo = new List<Animal>
            {
                new Cat ("djingal",12),
                new Dog("Sharo",3,Enumerations.DogBreed.German),
                new Frog("Kermit",2),
                new Cat ("varii",4),
                new Dog("Marko",24,Enumerations.DogBreed.German),
                new Frog("Moro",102)
            };
        }

        protected abstract void ArrangeZooMock();

        protected ZooMock()
        {
            this.PopulateData();
            this.ArrangeZooMock();
        }
    }
}
