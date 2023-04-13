using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : ApiController
    {
        List<Contact> contacts = new List<Contact>() {
            new Contact(){ ID=1,Age=20,Birthday=Convert.ToDateTime("1988-07-25"),Name="劫",Sex="男"},
            new Contact(){ ID=2,Age=18,Birthday=Convert.ToDateTime("1988-07-3"),Name="卡莎",Sex="女"},
            new Contact(){ ID=3,Age=1,Birthday=Convert.ToDateTime("1988-07-26"),Name="莫甘娜",Sex="女"},
            new Contact(){ ID=4,Age=4,Birthday=Convert.ToDateTime("1988-07-5"),Name="亚索",Sex="男"}
        };

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetListAll()
        {
            // 调用方式 Get
            //http://localhost:60463/api/Contact/id=1
            return contacts;
        }

        public Contact PostContactByID(int id)
        {
            // 调用方式 Post 插入数据 注意：第一个id是默认的可以随意传，第二个才是入参id
            //http://localhost:60463/api/Contact/id=1?id=1
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="age"></param>
        /// <param name="time"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public List<Contact> PostAddList(int id,int age,DateTime time,string name,string sex)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                contacts.Add(new Contact() { ID = id, Age = age, Birthday = time, Name = name, Sex = sex });
            }

            return contacts.ToList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="age"></param>
        /// <param name="time"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public List<Contact> PutUpdList(int id, int age, DateTime time, string name, string sex)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                contact.Age = age;
                contact.Birthday = time;
                contact.Name = name;
                contact.Sex = sex;
            }
            return contacts.ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contact> DeleteIDByList(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                contacts.Remove(contact);
            }
            return contacts.ToList();
        }

        public IEnumerable<Contact> GetListBySex(string sex)
        {
            //调用方式 Get
            //http://localhost:60463/api/Contact/id=1?sex=女
            return contacts.Where(item => item.Sex == sex);
        }
    }
}