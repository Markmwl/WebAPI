using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiByMVC.Models;

namespace WebApiByMVC.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<User> GetUsers()
        {
            return new List<User>() {
                new User() {ID =1,Name ="张三",Sex="男",Age =20,Message ="正常" },
                new User() {ID =2,Name ="李四",Sex="男",Age =21,Message ="正常" },
                new User() {ID =3,Name ="王五",Sex="男",Age =22,Message ="正常" },
                new User() {ID =4,Name ="赵六",Sex="男",Age =23,Message ="正常" }
             };
        }
        [HttpGet]
        public User Get(int id)
        {
            List<User> users = GetUsers();
            User us = users.Where(o => o.ID == id).FirstOrDefault();
            return us == null ? null :us;
        }
        [HttpGet]
        public string GetName(int id, string name)
        {
            return "我的ID是：" + id + ",我的姓名是：" + name;
        }

        [HttpPost]
        //没有ActionName，会识别为默认路由
        public void Post([FromBody]string value)
        {

        }

        [ActionName("NewPostAdd")]
        [HttpPost]
        public List<User> PostAdd([FromBody]User user)
        {
            List<User> users = GetUsers();
            if (user != null && user.ID != 0)
            {
                user.Message = "我是Post[FromBody],我是添加的新项！";
                users.Add(user);
            }

            return users;
        }


        [HttpPost, Route("GetNewData")]
        //此方法通过url传值，通过postmanURL测试
        public List<User> PostAddpost([FromUri]User user)
        {
            List<User> users = GetUsers();
            if (user != null && user.ID != 0)
            {
                user.Message = "我是Post[FromUri],我是添加的新项！";
                users.Add(user);
            }

            return users;
        }

        [ActionName("NewPoststring")]
        [HttpPost]
        //因为需要调用多个post方法所以加入特性路由再从ajax请求url中来区分ActionName来决定调用哪个post方法！
        public string Poststring([FromBody]string name)
        {
            string users = "[FromBody]post:你传入的是：" + name;
            return users;
        }
        [ActionName("NewPutstring")]
        [HttpPut]
        public string Put([FromBody]string name)
        {
            string users = "[FromBody]put:你传入的是：" + name;
            return users;
        }


        [ActionName("NewPutUpd")]
        [HttpPut]
        public List<User> PutUpd([FromBody]User user)
        {
            List<User> users = GetUsers();
            User us = users.Where(o => o.ID == user.ID).FirstOrDefault();
            if (us != null)
            {
                string username = us.Name;
                us.Name = user.Name;
                us.Sex = user.Sex;
                us.Age = user.Age;
                us.Message = "[FromBody]我是Put把原来的name" + username + "改为了:" + user.Name;
                return users;
            }
            return null;
          
        }


        [HttpPut,Route("PutUpData")]
        public List<User> PutUpdpost([FromUri]User user)
        {
            List<User> users = GetUsers();
            User us = users.Where(o => o.ID == user.ID).FirstOrDefault();
            if (us != null)
            {
                string username = us.Name;
                us.Name = user.Name;
                us.Sex = user.Sex;
                us.Age = user.Age;
                us.Message = "[FromUri]我是Put把原来的name" + username + "改为了:" + user.Name;
                return users;
            }
            return null;
        }

        [HttpDelete, Route("DelData")]
        public List<User> Delete([FromBody]int id)
        {
            List<User> users = GetUsers();
            User us = users.Where(o => o.ID == id).FirstOrDefault();
            if (us!=null)
            {
                users.Remove(us);
                return users;
            }
            return null;
        }

        [HttpDelete, Route("DelDatapost")]
        public List<User> Deletepost([FromUri]int id)
        {
            List<User> users = GetUsers();
            User us = users.Where(o => o.ID == id).FirstOrDefault();
            if (us!=null)
            {
                users.Remove(us);
                return users;
            }
            return null;
        }

    }
}
