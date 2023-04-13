using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WebApiByCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string url = "http://116.62.18.134:8002/api/Values/Getusers";
            //var str = HttpApi(url, "{}", "get");

            string url = "http://116.62.18.134:8002/api/Values/NewPostAdd";
            Dictionary<string, object> dicData = new Dictionary<string, object>();
            dicData.Add("ID", 5);
            dicData.Add("Name", "张雪");
            dicData.Add("Age", 30);
            dicData.Add("Sex", "女");
            dicData.Add("Message", "我是Post[FromBody],我是添加的新项！");
            string jsonstr = Newtonsoft.Json.JsonConvert.SerializeObject(dicData);
            var str = HttpApi(url, jsonstr, "post");

            //将返回json转字典
            var dicret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(str);

            //将返回json转对象
            var modret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModelWebApi>>(str);


            txtContent.Text = str;
            gvMain.DataSource = modret;
        }

        /// <summary>  
        /// 调用api返回json  
        /// </summary>  
        /// <param name="url">api地址</param>  
        /// <param name="jsonstr">接收参数</param>  
        /// <param name="type">类型</param>  
        /// <returns></returns>  
        public string HttpApi(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址  
            request.Accept = "text/html,application/xhtml+xml,*/*";
            //"application/x-www-form-urlencoded"
            //"application/json"
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();//get或者post  
            if (!request.Method.Equals("GET"))
            {
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
            }   
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//HttpWebResponse接收请求数据  
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class ModelWebApi
    {
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public Int32 Age { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// HTTP 内容类型(Content-Type)
    /// </summary>
    public class HttpContentType
    {
        /// <summary>
        /// 资源类型：普通文本
        /// </summary>
        public const string TEXT_PLAIN = "text/plain";

        /// <summary>
        /// 资源类型：JSON字符串
        /// </summary>
        public const string APPLICATION_JSON = "application/json";

        /// <summary>
        /// 资源类型：未知类型(数据流)
        /// </summary>
        public const string APPLICATION_OCTET_STREAM = "application/octet-stream";

        /// <summary>
        /// 资源类型：表单数据(键值对)
        /// </summary>
        public const string WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

        /// <summary>
        /// 资源类型：表单数据(键值对)。编码方式为 gb2312
        /// </summary>
        public const string WWW_FORM_URLENCODED_GB2312 = "application/x-www-form-urlencoded;charset=gb2312";

        /// <summary>
        /// 资源类型：表单数据(键值对)。编码方式为 utf-8
        /// </summary>
        public const string WWW_FORM_URLENCODED_UTF8 = "application/x-www-form-urlencoded;charset=utf-8";

        /// <summary>
        /// 资源类型：多分部数据
        /// </summary>
        public const string MULTIPART_FORM_DATA = "multipart/form-data";
    }
}
