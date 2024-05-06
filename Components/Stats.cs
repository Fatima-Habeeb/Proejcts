using Microsoft.AspNetCore.Mvc;
namespace webproject.Components
{
    public class Stats : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            object data = "Shaheen Afridi's all-round heroics win Lahore Qalandars second straight HBL PSL title";
            return View(data);
        }
    }
}
