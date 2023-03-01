namespace Task3
{
    abstract class Creature
    {
    }

    class Human : Creature
    {
        internal string Greeting() => "Привет, я человек!";
    }

    class Dog : Creature
    {
        internal string Bark() => "Гав!";
    }

    class Alien : Creature
    {
        internal string Command() => "Ты меня не видишь";
    }

    public class Task3
    {
        internal static void PrintMessageFrom(Creature creature)
        {
            var result = creature switch
            {
                Dog dog => dog.Bark(),
                Alien alien => alien.Command(),
                Human human => human.Greeting(),
                _ => throw new ArgumentException("Unsupported type"),
            };
            Console.WriteLine(result);
        }

        static List<Dog> FindDogs(List<Creature> creatures) =>
            (from creature in creatures where creature is Dog select creature as Dog).ToList();

        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            var creatures = new List<Creature> { new Alien(), new Dog(), new Human(), new Dog() };
            Console.WriteLine("Все сообщения:");

            foreach (var creature in creatures)
            {
                PrintMessageFrom(creature);
            }

            Console.WriteLine();
            Console.WriteLine("Сообщения только от собак:");
            foreach (var dog in FindDogs(creatures))
            {
                Console.WriteLine(dog.Bark());
            }
        }
    }
}