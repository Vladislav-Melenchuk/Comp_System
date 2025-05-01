using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_5
{
    public partial class Form1 : Form
    {
        private const int HorseCount = 5;
        private List<string> results = new List<string>();
        private object lockObj = new object();
        private int finishCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            results.Clear();
            finishCount = 0;
            foreach (var horse in horses)
                horse.Value = 0;

            for (int i = 0; i < HorseCount; i++)
            {
                int index = i;
                Task.Run(() => RunHorse(index));
            }
        }

        private void RunHorse(int index)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            while (horses[index].Value < horses[index].Maximum)
            {
                int step = rand.Next(1, 5);
                Invoke(new Action(() =>
                {
                    horses[index].Value = Math.Min(horses[index].Value + step, horses[index].Maximum);
                }));
                Thread.Sleep(rand.Next(50, 150));
            }

            lock (lockObj)
            {
                finishCount++;
                results.Add($"{finishCount}. Кінь {index + 1}");
                if (finishCount == HorseCount)
                {
                    Invoke(new Action(ShowResults));
                }
            }
        }

        private void ShowResults()
        {
            string message = string.Join("\n", results);
            MessageBox.Show(message, "Результати заїзду", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
