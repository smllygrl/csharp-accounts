using System;
using System.Collections.Generic;
using System.Text;

namespace CSpractice
{
    public class BankAccount
    {
            public string Number { get; }
            public string Owner { get; set; }
            public decimal Balance {
            get {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
            private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // can't deposit negative money
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            // can't withdraw negative money
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
            }
            // purchase cannot leave negative balance
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawl");
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);

        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
    }
}
