using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HW_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
            refreshTimer.Interval = 10000;
            refreshTimer.Tick += (s, e) => LoadProcesses();
            refreshTimer.Start();
        }

        private void LoadProcesses()
        {
            processList.Items.Clear();
            var processes = Process.GetProcesses().OrderBy(p => p.ProcessName);

            foreach (var process in processes)
            {
                string status = process.Responding ? "������" : "�� �������";
                var item = new ListViewItem(new[] {
                    process.ProcessName,
                    process.Id.ToString(),
                    status
                });
                processList.Items.Add(item);
            }
        }

        private void KillProcess(object sender, EventArgs e)
        {
            if (processList.SelectedItems.Count == 0)
            {
                MessageBox.Show("������ ������ ��� ����������.");
                return;
            }

            try
            {
                int id = int.Parse(processList.SelectedItems[0].SubItems[1].Text);
                var proc = Process.GetProcessById(id);
                proc.Kill();
                MessageBox.Show("������ ���������.");
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�������: {ex.Message}");
            }
        }

        private void StartNewProcess(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(startProcessTextBox.Text))
            {
                MessageBox.Show("������ ��'� ������� ��� �������.");
                return;
            }

            try
            {
                Process.Start(startProcessTextBox.Text);
                MessageBox.Show("������ ��������.");
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�������: {ex.Message}");
            }
        }
    }
}
