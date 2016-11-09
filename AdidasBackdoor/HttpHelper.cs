using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AdidasBackdoor
{
    class HttpHelper
    {
        private const string ClientKey = "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
        
        private async Task<string> GetRequest(string captchaId)
        {
            string url = string.Format("http://2captcha.com/res.php?key={0}&action=get&id={1}&json=1",ClientKey, captchaId);
            using (HttpClient client = new HttpClient())
            {
               using (HttpResponseMessage response = await client.GetAsync(url))
               { 
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        return mycontent;
                    }
                }
            }
        }

        public async Task<string> GetRequestWrapper(string captchaId)
        {
            string polling = await GetRequest(captchaId);
            while (polling.Contains("NOT_READY"))
            {
                Thread.Sleep(1000);
                polling = await GetRequest(captchaId);

            }
            return polling;
        }

        public async Task<string> PostRequest(string proxyAddress, string proxyPort, string sitekey)
        {
            //string mycontent;
            
            string proxy = string.Format("{0}:{1}", proxyAddress, proxyPort);
            string postData = string.Format("key={0}&method=userrecaptcha&googlekey={1}&proxy={2}&proxytype={3}&pageurl={4}", ClientKey, sitekey, proxy, "HTTP", "http://www.adidas.com");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync("http://2captcha.com/in.php?" + postData, null))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        return mycontent;
                    }
                }
            }

            //return mycontent = "OK|124324432424";
         }

        public async Task<string> PostRequestAdidas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, null))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        return mycontent;

                    }
                }
            }
        }

        public async Task<string> Start_Factory(string proxyAddress, string proxyPort, string sitekey)
        {
            string captchaID = await PostRequest(proxyAddress, proxyPort, sitekey);
            if (!captchaID.Contains("OK"))
            {
                return captchaID;
            }
            else
            {
                captchaID = captchaID.Split('|')[1];
                ResponseModel myobj = new ResponseModel();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string captcha = null;
                await Task.Run(async () => { captcha = await GetRequestWrapper(captchaID); });
                myobj = (ResponseModel)js.Deserialize(captcha, typeof(ResponseModel));

                return myobj.request;
            }
        }

        public string Get_URL(string sku, string size, string captcha)
        {
            return string.Format("http://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-MiniAddProduct?pid={0}_{1}&masterPid={2}&ajax=true&g-recaptcha-response={3}", sku, size, sku, captcha);
        }


    }
}
