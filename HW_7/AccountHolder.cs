using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    internal class AccountHolder
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int CreditScore { get; set; }
        public DateTime RegistrationDate { get; set; }

        public AccountHolder(string lastName, string firstName, int creditScore, DateTime registrationDate)
        {
            LastName = lastName;
            FirstName = firstName;
            CreditScore = creditScore;
            RegistrationDate = registrationDate;
        }
    }
}
