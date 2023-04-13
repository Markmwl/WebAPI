using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            var result = controller.Get(2);

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
            Assert.AreEqual("value1", result.Name);
            Assert.AreEqual("value2", result.Age);
        }

        [TestMethod]
        public void GetById()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            var result = controller.Get(2);

            // 断言
            Assert.AreEqual("user", result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            ValuesController controller = new ValuesController();
            var user = new User() { ID = 5, Name = "赵六", Sex = "男", Age = 23, Message = "正常" };
            // 操作
            controller.PostAdd(user);

            // 断言
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            controller.Put("mwl");

            // 断言
        }

        [TestMethod]
        public void Delete()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            controller.Delete(5);

            // 断言
        }
    }
}
