using DTO.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Test
{


    [TestClass]
    public class UnitTest1
    {
        private Type _magicType;

        [TestInitialize]
        public void Setup()
        {
            _magicType = GetTypes("Fns.EmployeeHelper");
        }

        [TestMethod]
        public void TestGetDiscount()
        {

            //test data expected 10
            double discountPercentage = 10;
            double Preimium = 100;

            double expected = 10;
      

            object[] tesdata = new object[] { discountPercentage, Preimium };

            MethodInfo magicMethod = _magicType.GetMethod("GetDiscount");
            object result = magicMethod.Invoke(magicMethod, tesdata);
            Assert.AreEqual(result, expected);

        }

     

        [TestMethod]
        public void TestGetDependendentPremium()
        {

            //test data
            double depdendentCost = 120;
            int totalPayCheck = 12;
            int depdendents = 1;

            double expected = 10;

            //Formula
            //(depdendentCost / totalPayCheck) * depdendents;

            object[] tesdata = new object[] { depdendentCost, totalPayCheck, depdendents };

            MethodInfo magicMethod = _magicType.GetMethod("GetDependendentPremium");
            object result = magicMethod.Invoke(magicMethod, tesdata);
            Assert.AreEqual(result, expected);

        }

    [TestMethod]
        public void TestGetNameDiscountFlag()
        {
            //test data
            var emp = new EmployeeDetails()
            {
                FirstName = "syed",
                LastName = "Abdi",
                Dependents = new List<DTO.Results.Info>()
                {
                    new DTO.Results.Info() { FirstName="Adam",LastName = "Steve"}
                }
            };

            string name = "a";

            object[] tesdata = new object[] { emp,name };

            MethodInfo magicMethod = _magicType.GetMethod("GetNameDiscountFlag");
            object result = magicMethod.Invoke(magicMethod, tesdata);
            Assert.IsTrue(Convert.ToBoolean(result));

        }

        [TestMethod]
        public void TestGetNameDiscountFlagFailed()
        {
            //test data
            var emp = new EmployeeDetails()
            {
                FirstName = "syed",
                LastName = "Abdi",
                Dependents = new List<DTO.Results.Info>()
                {
                    new DTO.Results.Info() { FirstName="John",LastName = "Steve"}
                }
            };
            string name = "a";
            object[] tesdata = new object[] { emp, name };

            MethodInfo magicMethod = _magicType.GetMethod("GetNameDiscountFlag");
            object result = magicMethod.Invoke(magicMethod, tesdata);
            Assert.IsFalse(Convert.ToBoolean(result));

        }





        //To find particular assembly
        public  static Type GetTypes(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            var t = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }
        

    }
}
