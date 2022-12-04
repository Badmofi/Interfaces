using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BartonLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            //add name to top of program
            Console.WriteLine("Carter Barton");
            //create two dog objects
            Dog d1 = new Dog();
            d1.Age = 2;
            d1.Name = "Rover";
            Dog d2 = new Dog(5, "123ido");
            //create a third dog using ICloneable
            Dog d3 = (Dog)d1.Clone();
            //create a car object
            Car c1 = new Car();
            //call DisplaySound four times passing each object as a parameter
            Console.WriteLine("This is " + d1.Name + " ->");
            DisplaySound(d1);
            Console.WriteLine("This is " + d2.Name + " ->");
            DisplaySound(d2);
            Console.WriteLine("This is a copy of " + d1.Name + " ->");
            DisplaySound(d3);
            Console.WriteLine("This is my auto ->");
            DisplaySound(c1);
            //compare Rover to 123ido
            string result = d1.Name + " is";
            switch (d1.CompareTo(d2))
            {
                case 1:
                    result += " older than ";
                    break;
                case 0:
                    result += " the same age as ";
                    break;
                case -1:
                    result += " younger than ";
                    break;
                       
            }
            result += d2.Name;
            Console.WriteLine(result);
            //prompt user to press key to end program
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        } //end main

        //Method: DisplayNoise
        //Send: IAudible 
        //Return: nothing
        //Desc: Calls MakeNoise method and displays string "A object goes sound"
        static void DisplaySound(IAudible sound)
        {
            Console.WriteLine("A " + sound.GetType().Name + " goes " + sound.MakeNoise());
        }
    } //end program

    //new interface!!!
    public interface IAudible
    {
        //Method: MakeNoise
        //Send: nothing
        //Return: string
        //Desc: implemented by any class that makes an audible noise
        string MakeNoise();
    } //end IAudible

    public class Car : IAudible
    {
        //implement MakeNoise method to return VROOM VROOM
        public string MakeNoise()
        {
            return "VROOM VROOM";
        }
    }//end car

    public class Dog : IAudible, IComparable<Dog>, ICloneable
    {
        //declaration of properties
        public int Age;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                //if first character of name is NOT a letter of the alphabet
                //source: https://stackoverflow.com/questions/3560393/how-to-check-first-character-of-a-string-if-a-letter-any-letter-in-c-sharp
                if (!String.IsNullOrEmpty(name) && Char.IsLetter(name[0]))
                {
                    char firstLetter = name[0];
                    name = firstLetter + value;
                }
                else
                    name = value;
            }
        }
        //default constructor
        public Dog() { }
        //custom constructor
        public Dog(int inAge, string inName)
        {
            Age = inAge;
            Name = inName;
        }
        //implement CompareTo to compare the age of two dogs
        //returns -1 if dog is younger, 0 if both dogs are same age, and 1 if dog is older
        public int CompareTo(Dog other)
            => Age < other.Age ? -1 : (Age == other.Age ? 0 : 1);

        //implement Clone(ICloneable)
        public object Clone()
        {
            //deep copy
            Dog d = new Dog
            { 
                Age = this.Age,
                Name = this.Name
            };
            return d;
        }

        //implement MakeNoise method to return WOOF WOOF
        public string MakeNoise()
        {
            return "WOOF WOOF";
        }
    }
}
