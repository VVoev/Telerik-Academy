using System;
using Contacts;
using Abstract;

namespace Models
{
    public class Chef
    {
        private ITableware bowl;
        private IIengidient[] ingredients;

        

        public void Cook(IIengidient[] list)
        {
            this.ingredients = list;
            this.bowl = this.GetBowl();
            this.ProcessIngredients(this.bowl, this.ingredients);
            Console.WriteLine("COOKING TIME...");
        }

        private void ProcessIngredients(ITableware bowl, IIengidient[] ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                this.Peel(ingredient);
                this.Cut(ingredient);
                bowl.Add(ingredient);
            }
        }

        private void Cut(IIengidient inredient)
        {
            Console.WriteLine($@"Cutting {inredient.GetType().Name}");
        }

        private void Peel(IIengidient inredient)
        {
            Console.WriteLine($@"Peeling {inredient.GetType().Name}");
        }

        private ITableware GetBowl()
        {
            return new Bowl();
        }

        private IIengidient GetCarrot()
        {
            return new Carrot();
        }

        private IIengidient GetPotato()
        {
            return new Potato();
        }
    }
}
