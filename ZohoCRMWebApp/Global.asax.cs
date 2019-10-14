using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.CRUD;
using ZCRMSDK.CRM.Library.Setup.RestClient;
using ZCRMSDK.OAuth.Client;
using ZCRMSDK.OAuth.Contract;
using ZohoCRMWebApp.Models;
using ZohoCRMWebApp;

namespace ZohoCRMWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static Dictionary<string, string> config = new Dictionary<string, string>()
        {
            {"client_id","1000.0ODYD5ODKO5K5K8GMOQP5WD4WPY8XH"},
            {"client_secret","26f7106d59edddb4bdb66de02dae5570cb132fab35"},
            {"redirect_uri","https://www.google.com/"},
            {"access_type","offline"},
            {"iamUrl","https://accounts.zoho.com"},
            {"persistence_handler_class","ZCRMSDK.OAuth.ClientApp.ZohoOAuthFilePersistence,ZCRMSDK"},
            {"oauth_tokens_file_path","C:\\Users\\ktnrk\\source\\repos\\tokens.txt"},
            {"mysql_username","root"},
            {"mysql_password",""},
            {"mysql_database","zohooauth"},
            {"mysql_server","localhost"},
            {"mysql_port","3306"},
            {"apiBaseUrl","https://www.zohoapis.com"},
            {"photoUrl","{photo_url}"},
            {"apiVersion","v2"},
            {"logFilePath","C:\\Users\\source\\repos\\ZohoCRMWebApp\\logFile.txt" },
            {"timeout",""},
            {"minLogLevel",""},
            {"domainSuffix","com"},
            {"currentUserEmail","development@salesbridge.be"}
        };


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var config1 = new ZohoCrmConfig(config);
            ZCRMRestClient.Initialize(config1._config);
            ZohoOAuthClient client = ZohoOAuthClient.GetInstance();
           /* string grantToken = "1000.6fbdef683757d53eef31aa26feba4e36.6f22da37ad747ca4dc376b3c6d72e9b6";
            ZohoOAuthTokens tokens = client.GenerateAccessToken(grantToken);
            string accessToken = tokens.AccessToken;
            string refreshToken = tokens.RefreshToken;*/
        }
    }
}
