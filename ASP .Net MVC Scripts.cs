using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web_MVC.Controllers
{

    public class RumahController : Controller
    {
        [Route("rumah")] // localhost/rumah
        public ActionResult Index()
        {
            return View();
        }

        [Route("rumah/about")] // localhost/rumah/about
        public ActionResult About()
        {
            return Content("<h3>Tentang Rumah</h3>");
        }

        [Route("page/{num}")]
        public ActionResult Page(int num)
        {
            return Content("Parameter : " + num);
        }

        [Route("page")]
        public ActionResult PostPage(int num)
        {
            return Content("Parameter : " + num);
        }

        [Route("user/{id}/{suffix}")]
        public ActionResult User(int id, string suffix)
        {
            List<string> users = new List<string> {
                "Galih",
                "Anggara",
                "Ahmad",
                "Ujang"
            };

            return Content(users[id] + suffix);
        }

        [Route("userd/{index}/{key}")]
        public ActionResult ListDic(int index, string key)
        {
            List<Dictionary<string, string>> dic = new List<Dictionary<string, string>>();
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("name", "Galih");
            d.Add("address", "Tangerang");
            dic.Add(d);

            d = new Dictionary<string, string>();
            d.Add("name", "Anggara");
            d.Add("address", "Jakarta");
            dic.Add(d); // dic[1]["address"] -> Jakarta

            return Content(dic[index][key]);
        }

        [Route("json")]
        public ActionResult GetJson()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://kodepos-2d475.firebaseio.com/");
                var req = client.GetAsync("list_kotakab/p12.json?print=pretty");
                req.Wait();

                var result = req.Result.Content.ReadAsStringAsync();
                result.Wait();

                
                return Content(result.Result);
            }
        }
    }
}