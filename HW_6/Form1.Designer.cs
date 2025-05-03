namespace HW_6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonDestination;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.NumericUpDown numericThreads;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonDestination = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.numericThreads = new System.Windows.Forms.NumericUpDown();
            this.labelThreads = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRep1
            // 
            this.buttonSource.Location = new System.Drawing.Point(30, 20);
            this.buttonSource.Name = "buttonRep1";
            this.buttonSource.Size = new System.Drawing.Size(200, 30);
            this.buttonSource.Text = "Вибрати директорію 1";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonRep1_Click);
            // 
            // buttonRep2
            // 
            this.buttonDestination.Location = new System.Drawing.Point(30, 60);
            this.buttonDestination.Name = "buttonRep2";
            this.buttonDestination.Size = new System.Drawing.Size(200, 30);
            this.buttonDestination.Text = "Вибрати директорію 2";
            this.buttonDestination.UseVisualStyleBackColor = true;
            this.buttonDestination.Click += new System.EventHandler(this.buttonRep2_Click);
            // 
            // labelThreads
            // 
            this.labelThreads.Location = new System.Drawing.Point(30, 100);
            this.labelThreads.Size = new System.Drawing.Size(120, 20);
            this.labelThreads.Text = "Кількість потоків:";
            // 
            // numericThreads
            // 
            this.numericThreads.Location = new System.Drawing.Point(160, 100);
            this.numericThreads.Minimum = 1;
            this.numericThreads.Maximum = 32;
            this.numericThreads.Value = 4;
            this.numericThreads.Size = new System.Drawing.Size(70, 23);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 140);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 30);
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(115, 140);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 30);
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(200, 140);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 30);
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 190);
            this.progressBar.Size = new System.Drawing.Size(400, 25);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(30, 225);
            this.labelStatus.Size = new System.Drawing.Size(400, 25);
            this.labelStatus.Text = "Очікування";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(470, 270);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.buttonDestination);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.numericThreads);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.Name = "Form1";
            this.Text = "Копіювання директорій";
            ((System.ComponentModel.ISupportInitialize)(this.numericThreads)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
