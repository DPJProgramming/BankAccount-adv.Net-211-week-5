using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount {

    /// <summary>
    /// represents a single users bank account
    /// </summary>
    internal class Account {

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
        /// <exception cref="NotImplementedException">positive number</exception>
        public void Deposit (double amount) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// amount of money from balance
        /// </summary>
        /// <param name="amount">positive number</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Withdraw(double amount) {
            throw new NotImplementedException();
        }
    }
}
