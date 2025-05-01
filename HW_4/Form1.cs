using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_4
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private int foundFilesCount = 0;
        private string logFilePath = "log.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            string directoryPath = textBoxPath.Text;
            string searchPattern = textBoxMask.Text;

            if (string.IsNullOrWhiteSpace(directoryPath) || string.IsNullOrWhiteSpace(searchPattern))
            {
                MessageBox.Show("Будь ласка, введіть шлях до папки та маску пошуку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Вказана папка не існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!searchPattern.Contains("*"))
            {
                if (searchPattern.StartsWith("."))
                    searchPattern = "*" + searchPattern;
                else
                    searchPattern = "*." + searchPattern;
            }

            cancellationTokenSource = new CancellationTokenSource();
            listBoxResults.Items.Clear();
            labelStatus.Text = "Пошук виконується...";
            foundFilesCount = 0;

            try
            {
                using (StreamWriter logWriter = new StreamWriter(logFilePath, false))
                {
                    await Task.Run(() => SearchFilesParallel(directoryPath, searchPattern, cancellationTokenSource.Token, logWriter));
                }

                labelStatus.Text = $"Пошук завершено. Знайдено файлів: {foundFilesCount}";
            }
            catch (OperationCanceledException)
            {
                labelStatus.Text = "Пошук скасовано.";
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Помилка: " + ex.Message;
            }
        }

        private void SearchFilesParallel(string directoryPath, string searchPattern, CancellationToken token, StreamWriter logWriter)
        {
            ConcurrentBag<string> allDirectories = new ConcurrentBag<string>();
            allDirectories.Add(directoryPath);

            try
            {
                foreach (var dir in Directory.EnumerateDirectories(directoryPath, "*", SearchOption.AllDirectories))
                {
                    allDirectories.Add(dir);
                }
            }
            catch (UnauthorizedAccessException) { }

            Parallel.ForEach(allDirectories, new ParallelOptions { CancellationToken = token }, currentDir =>
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(currentDir, searchPattern, SearchOption.TopDirectoryOnly))
                    {
                        token.ThrowIfCancellationRequested();

                        this.Invoke((MethodInvoker)(() =>
                        {
                            listBoxResults.Items.Add(file);
                        }));

                        Interlocked.Increment(ref foundFilesCount);

                        lock (logWriter)
                        {
                            logWriter.WriteLine(file);
                        }
                    }
                }
                catch (UnauthorizedAccessException) { }
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
