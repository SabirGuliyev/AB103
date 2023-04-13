using AbstractionInterface.Models;

namespace AbstractionInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Eagle eagle = new Eagle();
            Penguin penguin=new Penguin();
            Duck duck=new Duck();

            eagle.Fly();
             penguin.Swim();

            duck.Fly();
            duck.Swim();
        }
    }
}