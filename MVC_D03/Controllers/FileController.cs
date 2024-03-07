using Microsoft.AspNetCore.Mvc;

namespace MVC_D03.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile stdimage)
        {
            string fname = $"image.{stdimage.FileName.Split(".").Last()}";
            using (FileStream FS = new FileStream($"wwwroot/images/{fname}", FileMode.Create))
            {
                stdimage.CopyTo(FS);
            }

            return Content("Doneeeeeeee");
        }
    }
}
