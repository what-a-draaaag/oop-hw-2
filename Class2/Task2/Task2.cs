namespace Task2
{
    abstract class Animal
    {
        internal virtual string Name { get; }
        internal virtual string Action { get; }
        internal virtual string Sound { get; }

        internal void Talk()
        {
            Console.WriteLine($"{Name} {Action} '{Sound}'");
        }
    }

    internal class Cat : Animal
    {
        internal override string Name => "Кошка";
        internal override string Action => "мяучит";
        internal override string Sound => "мяу-мяу";
    }

    class Dog : Animal
    {
        internal override string Name => "Собака";
        internal override string Action => "гавкает";
        internal override string Sound => "гав-гав-гав";
    }

    class Goose : Animal
    {
        internal override string Name => "Гусь";
        internal override string Action => "гогочет";
        internal override string Sound => "га-га-га";
    }

    public class Task2
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            foreach (var animal in new List<Animal> { new Cat(), new Dog(), new Goose() })
            {
                animal.Talk();
            }
        }
    }
}