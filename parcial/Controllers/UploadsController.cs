using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UNFV.Portfolio.Controllers
{
    public class UploadsController : Controller
    {
        //POST: Uploads/UploadImages
        [HttpPost]
        public ActionResult UploadImages()
        {
            try
            {
                string filename = "";
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].FileName != "")
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory + "/Images/";
                        filename = Path.GetFileName(Request.Files[upload].FileName);
                        Request.Files[upload].SaveAs(Path.Combine(path, filename));
                    }
                }

                return Json(filename, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}