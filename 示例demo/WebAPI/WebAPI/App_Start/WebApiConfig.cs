using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //移除XML格式，采用Json进行数据交互
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //处理DateTime类型序列化后含有T的问题
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, new IsoDateTimeConverter());
        }
    }
}
