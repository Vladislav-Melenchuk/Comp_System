namespace HW_7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button buttonDepositA;
        private System.Windows.Forms.Button buttonDepositB;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ListBox listBoxBalances;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonTransfer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonDepositA = new Button();
            buttonDepositB = new Button();
            listBoxLog = new ListBox();
            listBoxBalances = new ListBox();
            comboBoxFrom = new ComboBox();
            comboBoxTo = new ComboBox();
            textBoxAmount = new TextBox();
            buttonTransfer = new Button();
            SuspendLayout();
            // 
            // buttonDepositA
            // 
            buttonDepositA.Location = new Point(30, 60);
            buttonDepositA.Name = "buttonDepositA";
            buttonDepositA.Size = new Size(100, 23);
            buttonDepositA.TabIndex = 0;
            buttonDepositA.Text = "Поповнити A";
            buttonDepositA.Click += buttonDepositA_Click;
            // 
            // buttonDepositB
            // 
            buttonDepositB.Location = new Point(140, 60);
            buttonDepositB.Name = "buttonDepositB";
            buttonDepositB.Size = new Size(100, 23);
            buttonDepositB.TabIndex = 1;
            buttonDepositB.Text = "Поповнити B";
            buttonDepositB.Click += buttonDepositB_Click;
            // 
            // listBoxLog
            // 
            listBoxLog.Location = new Point(30, 120);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(345, 109);
            listBoxLog.TabIndex = 8;
            // 
            // listBoxBalances
            // 
            listBoxBalances.Location = new Point(470, 20);
            listBoxBalances.Name = "listBoxBalances";
            listBoxBalances.Size = new Size(160, 214);
            listBoxBalances.TabIndex = 9;
            // 
            // comboBoxFrom
            // 
            comboBoxFrom.Location = new Point(30, 20);
            comboBoxFrom.Name = "comboBoxFrom";
            comboBoxFrom.Size = new Size(80, 23);
            comboBoxFrom.TabIndex = 4;
            // 
            // comboBoxTo
            // 
            comboBoxTo.Location = new Point(120, 20);
            comboBoxTo.Name = "comboBoxTo";
            comboBoxTo.Size = new Size(80, 23);
            comboBoxTo.TabIndex = 5;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(210, 20);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(80, 23);
            textBoxAmount.TabIndex = 6;
            // 
            // buttonTransfer
            // 
            buttonTransfer.Location = new Point(300, 20);
            buttonTransfer.Name = "buttonTransfer";
            buttonTransfer.Size = new Size(75, 23);
            buttonTransfer.TabIndex = 7;
            buttonTransfer.Text = "Переказ";
            buttonTransfer.Click += buttonTransfer_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(700, 270);
            Controls.Add(buttonDepositA);
            Controls.Add(buttonDepositB);
            Controls.Add(comboBoxFrom);
            Controls.Add(comboBoxTo);
            Controls.Add(textBoxAmount);
            Controls.Add(buttonTransfer);
            Controls.Add(listBoxLog);
            Controls.Add(listBoxBalances);
            Name = "Form1";
            Text = "Банківські операції";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
