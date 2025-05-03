using HW_7;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace HW_7
{
    public partial class Form1 : Form
    {
        private List<Account> accounts = new List<Account>();

        public Form1()
        {
            InitializeComponent();
            InitAccounts();
        }

        private void InitAccounts()
        {
            var holders = new List<AccountHolder>
            {
                new AccountHolder("Іваненко", "Анна", 850, DateTime.Now),
                new AccountHolder("Петренко", "Кирилл", 250, DateTime.Now),
                new AccountHolder("Мельник", "Олег", 450, DateTime.Now),
                new AccountHolder("Каримнек", "Владислав", 270, DateTime.Now)
            };

            for (int i = 0; i < holders.Count; i++)
            {
                var account = new Account(holders[i], 1000 + i * 1000);
                accounts.Add(account);
                comboBoxFrom.Items.Add($"Рахунок {i}");
                comboBoxTo.Items.Add($"Рахунок {i}");
            }

            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 1;

            UpdateBalances();
        }

        private void UpdateBalances()
        {
            listBoxBalances.Items.Clear();
            for (int i = 0; i < accounts.Count; i++)
            {
                listBoxBalances.Items.Add($"Рахунок {i}: {accounts[i].Balance} грн");
            }
        }

        private void buttonDepositA_Click(object sender, EventArgs e)
        {
            accounts[0].Deposit(1000);
            UpdateBalances();
        }

        private void buttonDepositB_Click(object sender, EventArgs e)
        {
            accounts[1].Deposit(1000);
            UpdateBalances();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введіть коректну суму!");
                return;
            }

            int fromIndex = comboBoxFrom.SelectedIndex;
            int toIndex = comboBoxTo.SelectedIndex;

            if (fromIndex == toIndex)
            {
                MessageBox.Show("Оберіть різні рахунки для переказу!");
                return;
            }

            Account from = accounts[fromIndex];
            Account to = accounts[toIndex];

            var op = new Operation(from, to, amount, listBoxLog);
            op.Execute();

            new Thread(() =>
            {
                Thread.Sleep(4000);
                Invoke(new Action(UpdateBalances));
            }).Start();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
