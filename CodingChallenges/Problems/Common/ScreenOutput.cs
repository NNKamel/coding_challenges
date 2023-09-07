using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.Common
{
    public static class ScreenOutput
    {
        public static List<StringBuilder> OutputList { get; set; } = new List<StringBuilder>();

        public static void NewResult()
        {
            OutputList.Add(new StringBuilder());
        }

        public static void ClearOutput()
        {
            OutputList = new List<StringBuilder>();
        }

        public static void AddLine(string line)
        {
            if (!OutputList.Any())
            {
                NewResult();
            }

            OutputList.Last().AppendLine(line);
        }
    }
}
