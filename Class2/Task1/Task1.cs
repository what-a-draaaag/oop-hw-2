using System.Text.RegularExpressions;

namespace Task1

{
    class JsonIntProperty
    {
        public static int InstanceCounter { get; private set; }
        public string Key { get; }
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                SetValueCounter++;
                _value = value;
            }
        }

        public int SetValueCounter { get; private set; }

        public JsonIntProperty(string key, int value = 0)
        {
            InstanceCounter++;
            Key = key;
            Value = value;
        }

        public string StringRepresentation
        {
            get => $"{Key}: {Value}";
            set
            {
                if (new Regex(@"\s*:\s*").Split(value) is not [var key, var stringValue])
                    throw new ArgumentException($"Incorrect JSON property format: '{value}'");
                if (key != Key)
                    throw new ArgumentException($"Property name is immutable");
                if (!int.TryParse(stringValue, out var intValue))
                    throw new FormatException($"For input string: \"{stringValue}\"");
                Value = intValue;
            }
        }

        public override string ToString() => StringRepresentation;
    }

    public class Task1
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            // throw new NotImplementedException(
            //     "Раскомментируйте код ниже и реализуйте требуемую функциональность в классе JsonIntProperty");
            var ageProperty = new JsonIntProperty("age", 21);
            Console.WriteLine(ageProperty);
            Console.WriteLine(ageProperty.StringRepresentation);
            ageProperty.Value += 1;
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age: 23";
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age   :   24";
            Console.WriteLine(ageProperty);
            try
            {
                ageProperty.StringRepresentation = "value : 10";
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }

            try
            {
                ageProperty.StringRepresentation = "age: ?";
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }

            try
            {
                ageProperty.StringRepresentation = "age = 10";
            }
            catch (Exception e)
            {
                // Console.WriteLine(e); - было
                Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }

            Console.WriteLine($"JSON value of 'age' has been set {ageProperty.SetValueCounter} time(s)");
            var countProperty = new JsonIntProperty("count");
            Console.WriteLine(countProperty);
            Console.WriteLine($"JSON value of 'count' has been set {countProperty.SetValueCounter} time(s)");
            Console.WriteLine(
                $"Class 'JsonIntProperty' instance has been created {JsonIntProperty.InstanceCounter} time(s)");
        }
    }
}