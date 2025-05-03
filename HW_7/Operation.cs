using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    public enum OperationStatus { Виконується, Виконана, Скасована }
    internal class Operation
    {
        private readonly Account _from;
        private readonly Account _to;
        private readonly decimal _amount;
        private readonly ListBox _log;
        public OperationStatus Status { get; private set; }

        public Operation(Account from, Account to, decimal amount, ListBox log)
        {
            _from = from;
            _to = to;
            _amount = amount;
            _log = log;
            Status = OperationStatus.Виконується;
        }

        public void Execute()
        {
            new Thread(() =>
            {
                bool success = false;
                var locks = new[] { _from, _to };
                Array.Sort(locks, (a, b) => a.GetHashCode().CompareTo(b.GetHashCode()));

                lock (locks[0].GetLock())
                {
                    lock (locks[1].GetLock())
                    {
                        if (_from.TryWithdraw(_amount))
                        {
                            _to.Deposit(_amount);
                            success = true;
                        }
                    }
                }

                if (!success)
                {
                    Thread.Sleep(3000);
                    lock (locks[0].GetLock())
                    {
                        lock (locks[1].GetLock())
                        {
                            if (_from.TryWithdraw(_amount))
                            {
                                _to.Deposit(_amount);
                                success = true;
                            }
                        }
                    }
                }

                Status = success ? OperationStatus.Виконана : OperationStatus.Скасована;

                _log.Invoke(new Action(() =>
                {
                    _log.Items.Add($"Операція з/на {_amount} грн: {Status}");
                }));
            }).Start();
        }
    }
}
