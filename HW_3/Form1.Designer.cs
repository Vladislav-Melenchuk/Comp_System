namespace HW_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView processList;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox startProcessTextBox;
        private System.Windows.Forms.Timer refreshTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.processList = new System.Windows.Forms.ListView();
            this.killButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.startProcessTextBox = new System.Windows.Forms.TextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.Location = new System.Drawing.Point(10, 10);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(760, 340);
            this.processList.TabIndex = 0;
            this.processList.View = System.Windows.Forms.View.Details;
            this.processList.FullRowSelect = true;
            this.processList.GridLines = true;
            this.processList.Columns.Add("Назва процесу", 400);
            this.processList.Columns.Add("ID", 100);
            this.processList.Columns.Add("Статус", 150);
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(10, 360);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(370, 40);
            this.killButton.TabIndex = 1;
            this.killButton.Text = "Завершити процес";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.KillProcess);
            // 
            // startProcessTextBox
            // 
            this.startProcessTextBox.Location = new System.Drawing.Point(10, 420);
            this.startProcessTextBox.Name = "startProcessTextBox";
            this.startProcessTextBox.Size = new System.Drawing.Size(370, 22);
            this.startProcessTextBox.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(390, 420);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(380, 25);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Запустити процес";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartNewProcess);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.startProcessTextBox);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.processList);
            this.Name = "Form1";
            this.Text = "Менеджер процесів";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
