using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.App_Data;

namespace WebAPI.Controllers
{
    /// <summary>
    /// C#User接口文档
    /// </summary>
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private MarkModel markConnection = new MarkModel();

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Get用户表")]
        public List<用户表> GetUsers()
        {
            return markConnection.用户表.ToList();
        }

        /// <summary>
        /// 获取T_EF_DEMO表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetT_EF_DEMO")]
        public List<T_EF_DEMO> GetT_EF_DEMO()
        {
            return markConnection.T_EF_DEMO.ToList();
        }
    }
}
