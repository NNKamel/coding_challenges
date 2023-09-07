namespace Problems.Common
{
    using CodingChallenges.Problems.Common;
    using u = Utils.Methods;
    public abstract class CodingProblem<T, G>
    {
        public List<T> inputs;
        public string otherInputs;
        public List<G> correctResults;
        public string problemName;

        public CodingProblem()
        {
            this.FillArray();
            this.NameProblem();
            this.AssignOtherInputs();
            this.FillCorrectResults();
        }

        internal abstract void NameProblem();

        internal abstract void FillArray();

        internal abstract void FillCorrectResults();

        internal abstract void AssignOtherInputs();

        public virtual void Solve()
        {
            Console.WriteLine($"starting solve: {problemName}");
            ScreenOutput.AddLine($"starting solve: {problemName}");
            if (!string.IsNullOrEmpty(this.otherInputs))
            {
                var targets = this.otherInputs.Split(",");
                var allInputs = this.inputs.Zip(targets, (i, o) => new { arr = i, t = o });
                var problemData = allInputs.Zip(this.correctResults, (i, r) => new { input = i, res = r });
                foreach (var data in problemData)
                {
                    // u.WriteArr(input, "input");
                    u.d(data.input, "input");
                    var output = psolve(data.input.arr, data.input.t);
                    u.d(output, "output");
                    u.d(data.res, "correct result");
                    if (string.Equals(u.ToPrettyString(data.res), u.ToPrettyString(output)))
                    {
                        u.print("$$$$ correct output $$$$");
                    }
                    else
                    {
                        u.print("#### INCORRECT ####");
                    }
                    ScreenOutput.NewResult();
                }
            }
            else
            {
                var problemData = this.inputs.Zip(this.correctResults, (i, r) => new { input = i, res = r });
                foreach (var data in problemData)
                {
                    // u.WriteArr(input, "input");
                    u.d(data.input, "input");
                    var output = psolve(data.input, "");
                    u.d(output, "output");
                    u.d(data.res, "correct result");
                    if (string.Equals(u.ToPrettyString(data.res), u.ToPrettyString(output)))
                    {
                        u.print("$$$$ correct output $$$$");
                    }
                    else
                    {
                        u.print("#### INCORRECT ####");
                    }
                    ScreenOutput.NewResult();
                }
            }
        }

        internal abstract G psolve(T inputs, string secondary);
    }
}