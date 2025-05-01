namespace HW_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ProgressBar[] horses;
        private System.Windows.Forms.Label[] labels;
        private System.Windows.Forms.Button startButton;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.horses = new System.Windows.Forms.ProgressBar[5];
            this.labels = new System.Windows.Forms.Label[5];
            this.startButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            for (int i = 0; i < 5; i++)
            {
                // Label
                this.labels[i] = new System.Windows.Forms.Label();
                this.labels[i].AutoSize = true;
                this.labels[i].Location = new System.Drawing.Point(12, 20 + i * 35);
                this.labels[i].Name = $"labelHorse{i + 1}";
                this.labels[i].Size = new System.Drawing.Size(50, 13);
                this.labels[i].TabIndex = i;
                this.labels[i].Text = $"Кінь {i + 1}";
                this.Controls.Add(this.labels[i]);

                // ProgressBar
                this.horses[i] = new System.Windows.Forms.ProgressBar();
                this.horses[i].Location = new System.Drawing.Point(70, 15 + i * 35);
                this.horses[i].Name = $"progressBarHorse{i + 1}";
                this.horses[i].Size = new System.Drawing.Size(400, 23);
                this.horses[i].TabIndex = i + 5;
                this.horses[i].Maximum = 100;
                this.Controls.Add(this.horses[i]);
            }

            // Start Button
            this.startButton.Location = new System.Drawing.Point(12, 200);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.Controls.Add(this.startButton);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Name = "Form1";
            this.Text = "Скачки";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
