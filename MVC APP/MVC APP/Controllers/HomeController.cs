using MVC_APP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_APP.Controllers
{
    public class HomeController : Controller
    {
        //samo 1
        static List<CoffeeBar> coffeeBars = new List<CoffeeBar>();
        public void getDataOnStartup(HttpPostedFileBase postedFile)
        {
            
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
             
            }
        }

        public ActionResult readContentsOfFile(String filePath)
        {
            string csvData = System.IO.File.ReadAllText(filePath);

            foreach(string row in csvData.Split('\n'))
            {
                if (string.IsNullOrEmpty(row))
                    break;
                coffeeBars.Add(new CoffeeBar
                {
                    Id = Convert.ToInt32(row.Split(',')[0]),
                    Name = row.Split(',')[1],
                    Distance = float.Parse(row.Split(',')[2])

                });
            }
            return View(coffeeBars);
        }
        public ActionResult Index()
        {
            //ke vrakja home page so 6te sliki tamu vo prototipot
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Alphabetical()
        {
            return View();
        }
        public ActionResult Distance()
        {
            return View();
        }
        public ActionResult Rating()
        {
            return View();
        }
        public ActionResult Favourites()
        {
            return View();
        }
        public ActionResult Adjust()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}