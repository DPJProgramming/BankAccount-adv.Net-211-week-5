using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount {

    /// <summary>
    /// represents a single users bank account
    /// </summary>
    public class Account {

        /// <summary>
        /// Create account with specific owner and balance of zero
        /// </summary>
        /// <param name="accOwner">full name of person that owns account</param>
        public Account(string accOwner) { 
            Owner = accOwner;
        }

        /// <summary>
        /// account holders first and last name
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// amount of money currently held in account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// specified positive amount of money to account 
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="NotImplementedException">takes positive number and returns new balance after adding</exception>
        public double Deposit(double amount) {

            if(amount <= 0) {
                throw new ArgumentOutOfRangeException("Amount must be more than 0.00");
            }
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// amount of money from balance
        /// </summary>
        /// <param name="amount">positive number</param>
        /// <exception cref="NotImplementedException">returns updated balance</exception>
        public double Withdraw(double amount) {


            if (amount > Balance) {
                throw new ArgumentException($"{nameof(amount)} cannot be greater than {nameof(Balance)}");
            }

            if (amount <= 0) {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than zero");
            }

            Balance -= amount;
            return Balance;
        }
    }
}
