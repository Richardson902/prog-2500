using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Console.WriteLine("Dog is at: X= " + dog.GetX() + " Y= " + dog.GetY());
            dog.Move("up", 20);
            Console.WriteLine("Dog moved to: X= " + dog.GetX() + " Y= " + dog.GetY());
            dog.Voice();

            SuperDog superDog = new SuperDog();
            Console.WriteLine("SuperDog is at: X= " + superDog.GetX() + " Y= " + superDog.GetY());
            superDog.Move("down", 50);
            Console.WriteLine("SuperDog moved to: X= " + superDog.GetX() + " Y= " + superDog.GetY());
            superDog.Voice();

            Chicken chicken = new Chicken();
            Console.WriteLine("Chicken is at: X= " + chicken.GetX() + " Y= " + chicken.GetY());
            chicken.Move();
            Console.WriteLine("Chicken moved to: X= " + chicken.GetX() + " Y= " + chicken.GetY());
            chicken.Voice();

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
