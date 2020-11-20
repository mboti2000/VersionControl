﻿using NUnit.Framework;
using System;
using System.Activities;
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

        [Test,
            TestCase("testpassword",false),
            TestCase("TESTPASSWORD", false),
            TestCase("testpassword123", false),
            TestCase("TestPassword123", true),
            TestCase("test", false),
            ]

        public void TestValidatePassword(string password, bool expectedResult) {
            var AC = new AccountController();
            var validateResult = AC.ValidatePassword(password);
            Assert.AreEqual(expectedResult,validateResult);
        }


        [Test,
            TestCase("cristiano.ronaldo@uni-corvinus.hu","MaczkoBotond7"),
             TestCase("maczko.botond@gmail.com", "Password123")
            ]
        public void TestRegisterHappypath(string email, string password)
        {
            var AC = new AccountController();
            var account = AC.Register(email,password);
            Assert.AreEqual(account.Email,email);
            Assert.AreEqual(account.Password, password);
            Assert.AreEqual(account.ID, Guid.Empty);
        }


        [Test,
            TestCase("cristiano.ronaldo.uni-corvinus.hu", "MaczkoBotond7"),
            TestCase("maczko.botond.gmail.com", "Password123"),
            TestCase("maczko.botond@gmail.com", "password123"),
            TestCase("maczko.botond@gmail.com", "Password"),
            ]
        public void TestRegisterValidateException(string email, string password)
        {
            var AC = new AccountController();
            try
            {
                var account = AC.Register(email, password);
                Assert.Fail();
            }
            catch(Exception ex) {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
            
        }



    }
}
