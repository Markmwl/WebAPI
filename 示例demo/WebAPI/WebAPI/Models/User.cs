using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required, Description("ID")]
        public int ID { get; set; }

        /// <summary>
        ///  名称
        /// </summary>
        [StringLength(maximumLength: 30, MinimumLength = 2), Description("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [Description("消息")]
        public string Message { get; set; }
    }
}