using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    internal class Account
    {
        private readonly object _lock = new object();

        public AccountHolder Holder { get; }
        public decimal Balance { get; private set; }

        public Account(AccountHolder holder, decimal initialBalance)
        {
            Holder = holder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            lock (_lock)
            {
                Balance += amount;
            }
        }

        public bool TryWithdraw(decimal amount)
        {
            lock (_lock)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    return true;
                }
                return false;
            }
        }

        public object GetLock() => _lock;
    }
}
