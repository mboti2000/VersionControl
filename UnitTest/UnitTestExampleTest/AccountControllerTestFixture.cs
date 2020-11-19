using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExampleTest
{
    public class AccountControllerTestFixture
    {
        [Test,
           TestCase("abcd1234", false),
           TestCase("irf@uni-corvinus", false),
           TestCase("irf.uni-corvinus.hu", false),
           TestCase("irf@uni-corvinus.hu", true)
           ]

        public void TestValidateEmail(string email, bool expectedResult)
        {
            var AC = new AccountController();
            var validateResult = AC.ValidateEmail(email);
            Assert.AreEqual(expectedResult, validateResult);
        }
    }
}
