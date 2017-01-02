namespace AcademyRPG
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExtendedEngine : Engine
    {
        private const string giantObject = "giant"; 
        private const string houseObject = "house";
        private const string knightObject = "knight";
        private const string ninjaObject = "ninja";
        private const string rockObject = "rock";

        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case giantObject:
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant(name,position));
                        break;
                    }
                case houseObject:
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position,owner));
                        break;
                    }
                case knightObject:
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name,position,owner));
                        break;
                    }
                case ninjaObject:
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }
                case rockObject:
                    {
                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(hitPoints, position));
                        break;
                    }
                default:
                   base.ExecuteCreateObjectCommand(commandWords);
                    break;

            }
        }

    }
}
