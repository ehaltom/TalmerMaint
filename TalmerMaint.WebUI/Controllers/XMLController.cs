using System.Web.Mvc;
using System.IO.Compression;

namespace TalmerMaint.WebUI.Controllers
{
    public class XMLController : Controller
    {
        // GET: XML
        [Authorize(Roles = "FileDownloads")]
        public FileResult Index()
        {
            var archive = Server.MapPath("~/temp/archive.zip");
            var files = Server.MapPath("~/XMLOutput");

            // clear any existing archive
            if (System.IO.File.Exists(archive))
            {
                System.IO.File.Delete(archive);
            }

            ZipFile.CreateFromDirectory(files, archive);

            // copy the selected files to the temp folder
            return File(archive, "application/zip", "archive.zip");
        }
    }
}