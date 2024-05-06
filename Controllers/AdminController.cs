using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webproject.Models;
using Microsoft.AspNetCore.Hosting;
using System.Numerics;

namespace webproject.Controllers
{
    public class AdminController : Controller
    {
        
    private readonly IWebHostEnvironment webHostEnvironment;

    public AdminController(IWebHostEnvironment environment)
    {
        webHostEnvironment = environment;
    }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Addplayer(string team, string player, string type, IFormFile file)
        {
            string temp = team;
            temp = temp.Replace(" ", "");
            temp = temp.ToLower();
            if (temp == "lahoreqalandars" && file != null && file.Length > 0  && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "LQ_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var relativeImagePath = "/" + Path.Combine("Images", "LQ_Players", fileName).Replace("\\", "/"); ;

                LahoreQalandars lq = new LahoreQalandars();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.LahoreQalandars.Add(lq);
                    tc.SaveChanges();
                }


            }
            if (temp == "multansultans" && file != null && file.Length > 0 && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "MS_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var relativeImagePath = "/" + Path.Combine("Images", "MS_Players", fileName).Replace("\\", "/"); ;

                MultanSultans lq = new MultanSultans();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.MultanSultans.Add(lq);
                    tc.SaveChanges();
                }


            }
            if (temp == "quettagladiators" && file != null && file.Length > 0  && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "QG_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var relativeImagePath = "/" + Path.Combine("Images", "QG_Players", fileName).Replace("\\", "/"); ;

                QuettaGladiators lq = new QuettaGladiators();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.QuettaGladiators.Add(lq);
                    tc.SaveChanges();
                }


            }
            if (temp == "karachikings" && file != null && file.Length > 0  && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "KK_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var relativeImagePath = "/" + Path.Combine("Images", "KK_Players", fileName).Replace("\\", "/"); ;

                KarachiKings lq = new KarachiKings();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.KarachiKings.Add(lq);
                    tc.SaveChanges();
                }


            }
            if (temp == "islamabadunited" && file != null && file.Length > 0 && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "IU_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

        
                var relativeImagePath = "/" + Path.Combine("Images", "IU_Players", fileName).Replace("\\", "/"); ;

                IslamabadUnited lq = new IslamabadUnited();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.IslamabadUnited.Add(lq);
                    tc.SaveChanges();
                }


            }

            if (temp == "peshawarzalmi" && file != null && file.Length > 0 && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(type))
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "PS_Players");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var relativeImagePath = "/" + Path.Combine("Images", "PS_Players", fileName).Replace("\\", "/"); ;

                PeshawarZalmi lq = new PeshawarZalmi();
                lq.Name = player;
                lq.Type = type;
                lq.path = relativeImagePath;
                using (TeamContext tc = new TeamContext())
                {
                    tc.PeshawarZalmi.Add(lq);
                    tc.SaveChanges();
                }


            }


            return RedirectToAction("Add");
        }
    
        public IActionResult Remove()
        {
            return View("Remove");
        }

        public IActionResult RemovePlayer(string team, string player, string type)
        {
            string temp = team;
            temp = temp.Replace(" ", "");
            temp = temp.ToLower();

            using (TeamContext tc = new TeamContext())
            {
                if (temp == "lahoreqalandars")
                {
                    var lq = tc.LahoreQalandars.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.LahoreQalandars.Remove(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "multansultans")
                {
                    var lq = tc.MultanSultans.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.MultanSultans.Remove(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "quettagladiators")
                {
                    var lq = tc.QuettaGladiators.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.QuettaGladiators.Remove(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "karachikings")
                {
                    var lq = tc.KarachiKings.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.KarachiKings.Remove(lq);
                        tc.SaveChanges();
                    }
                }
    
                else if (temp == "islamabadunited")
                {
                    var lq = tc.IslamabadUnited.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.IslamabadUnited.Remove(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "peshawarzalmi")
                {
                    var lq = tc.PeshawarZalmi.FirstOrDefault(p => p.Name == player && p.Type == type);
                    if (lq != null)
                    {
                        tc.PeshawarZalmi.Remove(lq);
                        tc.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Remove");
        }


        public IActionResult Update()
        {
            return View("Update");
        }

        public IActionResult UpdatePlayer(string team, string oldName, string oldType, string newName, string newType, IFormFile file)
        {
            string temp = team;
            temp = temp.Replace(" ", "");
            temp = temp.ToLower();

            using (TeamContext tc = new TeamContext())
            {
                if (temp == "lahoreqalandars")
                {
                    var lq = tc.LahoreQalandars.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "LQ_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            lq.path = "/" + Path.Combine("Images", "LQ_Players", fileName).Replace("\\", "/"); ;

                        }
                            tc.LahoreQalandars.Update(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "multansultans")
                {
                    var lq = tc.MultanSultans.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "MS_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            lq.path = "/" + Path.Combine("Images", "MS_Players", fileName).Replace("\\", "/"); 

                        }
                        tc.MultanSultans.Update(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "quettagladiators")
                {
                    var lq = tc.QuettaGladiators.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "QG_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            lq.path = "/" + Path.Combine("Images", "QG_Players", fileName).Replace("\\", "/"); 

                        }
                        tc.QuettaGladiators.Update(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "karachikings")
                {
                    var lq = tc.KarachiKings.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "KK_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            lq.path = "/" + Path.Combine("Images", "KK_Players", fileName).Replace("\\", "/"); 

                        }
                        tc.KarachiKings.Update(lq);
                        tc.SaveChanges();
                    }
                }
    
                 else if (temp == "islamabadunited")
                {
                    var lq = tc.IslamabadUnited.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "IU_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

       
                    lq.path = "/" + Path.Combine("Images", "IU_Players", fileName).Replace("\\", "/"); ;

                        }
                        tc.IslamabadUnited.Update(lq);
                        tc.SaveChanges();
                    }
                }
                else if (temp == "peshawarzalmi")
                {
                    var lq = tc.PeshawarZalmi.FirstOrDefault(p => p.Name == oldName && p.Type == oldType);
                    if (lq != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            lq.Name = newName;
                        }
                        if (!string.IsNullOrEmpty(newType))
                        {
                            lq.Type = newType;
                        }
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "PS_Players");
                            var filePath = Path.Combine(folderPath, fileName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            lq.path = "/" + Path.Combine("Images", "PS_Players", fileName).Replace("\\", "/"); 

                        }
                        tc.PeshawarZalmi.Update(lq);
                        tc.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Update");
        }



        public IActionResult AdminForm(string email, string password)
        {
            if (email == "admin@psl.pk" && password == "123")
            {
                ViewBag.CssFile = "admin.css";
                return View("Admin");
            }
            else
            {
                return View("Fail");
            }
        }

        public IActionResult List()
        {
            var allTableData = new List<List<Dictionary<string, object>>>();

            
            using (var dbContext = new TeamContext())
            {
                allTableData.Add(GetTableData<LahoreQalandars>(dbContext.LahoreQalandars, "LahoreQalandars", item => new { Name = item.Name, Type = item.Type }));
                allTableData.Add(GetTableData<KarachiKings>(dbContext.KarachiKings, "KarachiKings", item => new { Name = item.Name, Type = item.Type }));
                allTableData.Add(GetTableData<MultanSultans>(dbContext.MultanSultans, "MultanSultans", item => new { Name = item.Name, Type = item.Type }));
                allTableData.Add(GetTableData<PeshawarZalmi>(dbContext.PeshawarZalmi, "PeshawarZalmi", item => new { Name = item.Name, Type = item.Type }));
                allTableData.Add(GetTableData<IslamabadUnited>(dbContext.IslamabadUnited, "IslamabadUnited", item => new { Name = item.Name, Type = item.Type }));
                allTableData.Add(GetTableData<QuettaGladiators>(dbContext.QuettaGladiators, "QuettaGladiators", item => new { Name = item.Name, Type = item.Type }));
            }

            return View("List", allTableData);
        }

        private List<Dictionary<string, object>> GetTableData<T>(DbSet<T> table, string tableName, Func<T, object> propertySelector) where T : class
        {
            var tableData = new List<Dictionary<string, object>>();

            foreach (var item in table)
            {
                var properties = propertySelector(item);

                var dictionary = new Dictionary<string, object>
        {
            { "TableName", tableName },
            { "Name", properties.GetType().GetProperty("Name").GetValue(properties) },
            { "Type", properties.GetType().GetProperty("Type").GetValue(properties) }
        };

                tableData.Add(dictionary);
            }

            return tableData;
        }

    }
}
