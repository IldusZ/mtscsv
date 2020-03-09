using MTSTaskCSV.Models;
using System;
using System.Web;
using System.Web.Mvc;
using MTSTaskCSV.Helpers;
using System.Threading.Tasks;
using System.Linq;

namespace MTSTaskCSV.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    if (postedFile.FileName.EndsWith(".csv"))
                    {
                        // Сохранение отправленного файла
                        var filePath = Server.MapPath($@"\App_Data\{Guid.NewGuid()}.csv");
                        postedFile.SaveAs(filePath);

                        using (var db = new CSVContext())
                        {
                            int countBefore = db.Persons.Count();

                            // Сохранение в БД
                            await DBOperations.SaveDataAsync(filePath);

                            // Выборка сохраненных записей
                            var records = db.Persons.OrderBy(p => p.Id).Skip(countBefore).ToList();

                            return View(records);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Этот формат файла не поддерживается");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Необходимо выбрать файл");
                    return View();
                }
            }

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}