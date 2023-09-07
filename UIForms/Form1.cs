
namespace UIForms
{
    using CodingChallenges.Problems.Common;
    using Guna.UI2.WinForms;
    using Problems;
    using Problems.Common;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(18,18,18);

            var challenges = new List<dynamic>()
            {
                new ThreeSum(),
                new ThreeSumClosest(),
                new FourSum(),
                new FourSumII(),
                new CountQuadruplets(),
                new AddTwoNumbers(),
                new TwoSum(),
                new TwoSumSorted(),
                new LongestNonRepeatingString(),
            };

            foreach (var challenge in challenges)
            {
                Guna2Button b = GetChallengeButton(challenge);

                flowLayoutPanel1.Controls.Add(b);
                //flowLayoutPanel1.BackColor = Color.Red;
                flowLayoutPanel1.AutoSize = true;
                flowLayoutPanel1.AutoScroll = false;
                //flowLayoutPanel1.Width = 100;
                //flowLayoutPanel1.Padding = Padding.Empty;
            }
        }

        private Guna2Button GetChallengeButton(dynamic challenge)
        {
            Guna2Button b = new()
            {
                Text = challenge.problemName,
                Dock = DockStyle.Top,
                Margin = Padding.Empty,
                BackColor = Color.FromArgb(20, 20, 20),
            //Padding = Padding.Empty,
        };

            //b.SendToBack();
            b.Click += OnChallengeButtonClick(challenge);
            return b;
        }

        private EventHandler OnChallengeButtonClick(dynamic challenge)
        {
            return delegate
            {
                ClearOutput();
                ScreenOutput.NewResult();
                challenge.Solve();
                foreach (var logItem in ScreenOutput.OutputList)
                {
                    Guna2Panel p = new Guna2Panel();
                    p.Dock = DockStyle.Bottom;
                    p.Height = 50;
                    //p.BackColor = Color.Orange;
                    Guna2TextBox textb = GetTextBox();
                    textb.Text = logItem.ToString();
                    Guna2Button button = GetCollapsingButton(p, textb);
                    p.Controls.Add(button);
                    p.Controls.Add(textb);
                    button.SendToBack();
                    guna2Panel2.Controls.Add(p);
                }
            };
        }

        private static Guna2Button GetCollapsingButton(Guna2Panel p, Guna2TextBox t)
        {
            Guna2Button button = new Guna2Button();
            button.Dock = DockStyle.Left;
            button.Height = 50;
            button.Width = 50;
            button.Text = ">";
            button.Click += delegate
            {
                if (button.Height == 300)
                {
                    p.Height = 50;
                    button.Text = ">";
                    t.Multiline = false;
                }
                else
                {
                    p.Height = 300;
                    button.Text = "^";
                    t.Multiline = true;
                }
            };
            return button;
        }

        private static Guna2TextBox GetTextBox()
        {
            Guna2TextBox textb = new Guna2TextBox();
            textb.ScrollBars = ScrollBars.Both;
            textb.ReadOnly = true;
            textb.Dock = DockStyle.Fill;
            textb.Height = 20;
            textb.Multiline = false;
            return textb;
        }

        private void guna2Button1_Click(object sender, EventArgs e) => ClearOutput();

        private void ClearOutput()
        {
            ScreenOutput.ClearOutput();
            guna2Panel2.Controls.Clear();
        }
    }
}