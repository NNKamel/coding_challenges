namespace Utils
{
    using LINQPad;
    using Newtonsoft.Json;

    class Methods
    {
        public static void WriteArr(IEnumerable<int> arr, string name)
        {
            var size = arr.Count();
            string s = "";
            s += $"{name}: \n| ";
            for (int i = 0; i < size; i++)
            {
                s += $"{i} | ";
            }
            s += $"\n| ";
            foreach (var ele in arr)
            {
                s += $"{ele} | ";
            }
            // s+="\n";
            Console.WriteLine(s);
        }

        public static void print(string s)
        {
            Console.WriteLine(s);
        }

        public static string ToPrettyString(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public static T d<T>(T value, string name)
        {
            Console.WriteLine($"== {name} ==");
            Console.WriteLine(ToPrettyString(value) + "\n== ==");
            return value;
        }
    }
}
