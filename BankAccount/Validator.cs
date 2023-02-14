using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount {
    public class Validator {

        public static bool isWithinRange(double min, double max, double testValue) {
            return testValue >= min && testValue <= max;
        }
    }
}
