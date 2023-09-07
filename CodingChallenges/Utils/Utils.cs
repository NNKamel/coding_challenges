namespace Utils
{
    using CodingChallenges.Problems.Common;
    using LINQPad;
    using Newtonsoft.Json;
    using System.Diagnostics;

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
            ScreenOutput.AddLine(s);
            Debug.WriteLine(s);
        }

        public static void print(string s)
        {
            ScreenOutput.AddLine(s);
            Debug.WriteLine(s);
        }

        public static string ToPrettyString(dynamic value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public static T d<T>(T value, string name)
        {
            ArgumentNullException.ThrowIfNull(value);
            ScreenOutput.AddLine($"== {name} ==");
            Debug.WriteLine($"== {name} ==");
            ScreenOutput.AddLine(ToPrettyString(value));
            ScreenOutput.AddLine("\n== ==");
            Debug.WriteLine(ToPrettyString(value) + "\n== ==");
            return value;
        }
    }
}
