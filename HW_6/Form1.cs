using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW_6
{
    public partial class Form1 : Form
    {
        private string sourcePath;
        private string destPath;
        private CancellationTokenSource cancelTokenSource;
        private ManualResetEventSlim pauseEvent;
        private ConcurrentQueue<(string src, string dst)> filesToCopy;
        private int totalFiles = 0;
        private int copiedFiles = 0;

        public Form1()
        {
            InitializeComponent();
            pauseEvent = new ManualResetEventSlim(true);
            filesToCopy = new ConcurrentQueue<(string src, string dst)>();
        }

        private void buttonRep1_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                sourcePath = fbd.SelectedPath;
        }

        private void buttonRep2_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                destPath = fbd.SelectedPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destPath))
            {
                MessageBox.Show("Оберіть директорії");
                return;
            }

            cancelTokenSource = new CancellationTokenSource();
            filesToCopy = new ConcurrentQueue<(string, string)>();
            copiedFiles = 0;

            progressBar.Value = 0;
            labelStatus.Text = "Підготовка файлів";

            Task.Run(() => PrepareFiles());
        }

        private void PrepareFiles()
        {
            var allFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
            totalFiles = allFiles.Length;

            foreach (var file in allFiles)
            {
                var relativePath = Path.GetRelativePath(sourcePath, file);
                var destFile = Path.Combine(destPath, relativePath);
                filesToCopy.Enqueue((file, destFile));
            }

            this.Invoke(() =>
            {
                progressBar.Maximum = totalFiles;
                labelStatus.Text = "Копіювання";
            });

            int threadCount = (int)numericThreads.Value;
            for (int i = 0; i < threadCount; i++)
            {
                ThreadPool.QueueUserWorkItem(_ => CopyWorker(cancelTokenSource.Token));
            }
        }

        private void CopyWorker(CancellationToken token)
        {
            while (filesToCopy.TryDequeue(out var filePair))
            {
                pauseEvent.Wait();

                if (token.IsCancellationRequested)
                    return;

                Directory.CreateDirectory(Path.GetDirectoryName(filePair.dst));
                File.Copy(filePair.src, filePair.dst, true);

                Interlocked.Increment(ref copiedFiles);
                this.Invoke(() =>
                {
                    progressBar.Value = Math.Min(copiedFiles, totalFiles);
                    labelStatus.Text = $"Скопійовано {copiedFiles}/{totalFiles}";

                    
                    if (copiedFiles == totalFiles)
                    {
                        MessageBox.Show("Копіювання завершено", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelStatus.Text = "Готово";
                    }
                });
            }
        }


        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (pauseEvent.IsSet)
            {
                pauseEvent.Reset();
                labelStatus.Text = "Пауза";
            }
            else
            {
                pauseEvent.Set();
                labelStatus.Text = "Продовження";
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cancelTokenSource?.Cancel();
            pauseEvent.Set();
            labelStatus.Text = "Зупинено";
        }
    }
}
