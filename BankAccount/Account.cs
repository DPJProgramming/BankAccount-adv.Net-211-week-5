using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccount {

    /// <summary>
    /// represents a single users bank account
    /// </summary>
    public class Account {
        private string owner;

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
        public string? Owner {
            get { return owner; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Owner cannot be null");
                }

                if(value.Trim() == string.Empty) {
                    throw new ArgumentException($"{nameof(Owner)} must have text");
                }

                if (ValidOwnerName(value)) {
                    owner = value;
                }

                else {
                    throw new ArgumentException($"{nameof(Owner)} can only contain letters (spaces allowed).");

                } 
            }
        }

        /// <summary>
        /// Checks if owner name is < 20 characters a-z and white space is allowed
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidOwnerName(string ownerName) {
            char[] validCharacters = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
            
            ownerName= ownerName.ToLower();

            const int MaxLengthOwnerName = 20;

            if(ownerName.Length > MaxLengthOwnerName) {
                return false;
            }

            foreach (char letter in ownerName) {
                if (letter != ' ' && !validCharacters.Contains(letter)) {
                    return false;
                }
            }

            return true;
        }

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
