using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ImageController : Controller
    {
        private ProductDatabaseEntities db = new ProductDatabaseEntities();

        // GET: Image
        public ActionResult Addimg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addimg(ProductListData p)
        {
            string filename = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
            string filename1 = Path.GetFileNameWithoutExtension(p.Large_ImageFile.FileName);

            string extension = Path.GetExtension(p.ImageFile.FileName);
            string extension1 = Path.GetExtension(p.Large_ImageFile.FileName);

            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;

            p.Small_image = "~/SmallImg/" + filename;
            p.Large_image = "~/LargeImg/" + filename1;
            
            filename = Path.Combine(Server.MapPath("~/SmallImg"), filename);
            filename1 = Path.Combine(Server.MapPath("~/LargeImg"), filename1);

            p.ImageFile.SaveAs(filename);
            p.Large_ImageFile.SaveAs(filename1);

            db.ProductListDatas.Add(p);
            db.SaveChanges();
            ModelState.Clear();

            return View();
        }

    }
}