using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double amount) {

            acc.Deposit(amount);

            Assert.AreEqual(amount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance() {

            double depositAmount = 100;
            double expectedReturn = 100;
            double returnValue = acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, returnValue);

        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArguementException(double invalidDepositAmount) {

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
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
        [DataRow(100, 50)]
        [DataRow(50, 12.50)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnUpdatedBalance(double initialDeposit, double withdrawalAmount) {
            //arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);
                
            //act
            double returnedBalance = acc.Withdraw(withdrawalAmount);

            //assert
            Assert.AreEqual(expectedBalance, returnedBalance);
        }

        [TestMethod]
        [DataRow (0)]
        [DataRow (-1)]
        [DataRow (-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArguementNotFoundException(double withdrawAmount) {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArguementsException() {
            double withdrawalAmount = 1000;
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawalAmount));

        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsNull_ThrowsArguementException() {
            
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "");
        }

        [TestMethod]
        [TestCategory("Owner")]
        [DataRow("David")]
        [DataRow("David Jarvis")]
        [DataRow("kndnerbtrsntrb")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName) {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [TestCategory("Owner")]
        [DataRow("David 2")]
        [DataRow("@#$%")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName) {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}