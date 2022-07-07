
// "version": "0.2.0",
// "configurations": [
//     {
//         "name": ".NET Core Launch (console)",
//         "type": "coreclr",
//         "request": "launch",
//         "preLaunchTask": "build",
//         "program": "${workspaceFolder}/bin/Debug/net6.0/CodingChallenges.dll",
//         "args": [],
//         "cwd": "${workspaceFolder}",
//         "console": "internalConsole",
//         "stopAtEntry": false
//     },
//     {
//         "name": ".NET Core Attach",
//         "type": "coreclr",
//         "request": "attach"
//     }
// ]
// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using LINQPad;
using u = Utils.Methods;
using Problems;
using Problems.Common;
using System.Text;



// var arr5 = new int[] { 2, 2, -1, -1, -1, 3, -2 };
// u.WriteArr(arr5, "arr5");
// var y = ThreeSumAnswer(arr5);
// y.Dump("ThreeSumAnswer");

var solutions = new Dictionary<int, CodingProblem>()
{
    {1, new ThreeSum()},
    {2, new ThreeSumClosest()},
};
string savedMenu = "";

var input = GetMenuInput();
while (input > 0)
{
    solutions[input].Solve();
    input = GetMenuInput();
}

int GetMenuInput()
{
    u.print($"choose problem, or -1 to exit");
    u.print(GetMenuOptions(solutions));
    return Int32.Parse(Console.ReadLine());
}

string GetMenuOptions(Dictionary<int, CodingProblem> options)
{
    if (string.IsNullOrEmpty(savedMenu))
    {
        string menu = "== Menu ==\n";
        StringBuilder sb = new StringBuilder(menu);
        foreach (var option in options)
        {
            sb.Append($"{option.Key} - {option.Value.problemName}\n");
        }
        savedMenu = sb.ToString();
    }
    return savedMenu;
}