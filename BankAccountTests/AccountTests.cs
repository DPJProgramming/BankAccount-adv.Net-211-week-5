using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests {
    [TestClass()]
    public class AccountTests {

        private Account acc;
        
        [TestInitialize]
        public void CreateDefaultAccount() {
            acc = new Account("David");
        }

        [TestMethod()]
        [DataRow(100)]
        public void Deposit_APositiveAmount_AddToBalance(double amount) {

            acc.Deposit(amount);

            Assert.AreEqual(amount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance() {

            double depositAmount = 100;
            double expectedReturn = 100;
            double returnValue = acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, returnValue);

        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArguementException(double invalidDepositAmount) {

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        //Withdraw 0
        //withdraw negetive amount
        //withdrawing a positive amount
        //withdrawing more than balance

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance() {
            //Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            //Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance;

            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ReturnUpdatedBalance() {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow (0)]
        [DataRow (-1)]
        [DataRow (-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArguementNotFoundException() {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArguementsException() {
            Assert.Fail();
        }
    }
}