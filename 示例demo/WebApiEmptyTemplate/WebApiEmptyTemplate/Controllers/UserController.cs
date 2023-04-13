using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Gettxt()
        {
            // API 名字 最好是以请求方式开头 
            //假如你是Get 请求  最好是GetXXX
            //调用方式 Get
            //http://localhost:60463/api/User/id=1
            return "如果没有入参的话，调用url会自动找寻到没入参的我!";
        }

        [HttpGet]
        public Dictionary<string,string> Getuser(string username, string password)
        {
            // API 名字 最好是以请求方式开头 
            //假如你是Get 请求  最好是GetXXX
            //调用方式 Get
            //http://localhost:60463/api/User/id=1?username=马文磊&password=123456
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("用户名",username);
            dic.Add("密码", password);
            return dic;
        }
    }
}