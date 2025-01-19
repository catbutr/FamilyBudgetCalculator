using FamilyBudgetCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FamilyBudgetCalculator.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var newVM = new IndexViewModel
            {
                Categories = db.Categories.ToList(),
                Types = db.Types.ToList(),
                Transactions = db.Transactions.ToList(),
                Users = db.Users.ToList()
            };
            return View(newVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// ���������� ������������ � ���� ������
        /// </summary>
        /// <param name="user">������������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        public IActionResult CreateUserPage()
        {
            return View("~/Views/Home/CreationPages/CreateUserPage.cshtml");
        }

        public IActionResult Users()
        {
            return View("~/Views/Home/ListPages/Users.cshtml", db.Users);
        }

        /// <summary>
        /// �������� ������������ �� ���� ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                User user = new User { UserID = id.Value };
                db.Entry(user).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Users");
            }
            return NotFound();
        }

        /// <summary>
        /// GET-������ �������������� ������������
        /// </summary>
        /// <param name="id">id ������������ � ���� ������</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id != null)
            {
                User? user = await db.Users.FirstOrDefaultAsync(p => p.UserID == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }

        /// <summary>
        /// POST-������ �������������� ������������
        /// </summary>
        /// <param name="user">������������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        /// <summary>
        /// ���������� ��������� � ���� ������
        /// </summary>
        /// <param name="user">������������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        /// <summary>
        /// �������� ��������� �� ���� ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = new Category { CategoryID = id.Value };
                db.Entry(category).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Categories");
            }
            return NotFound();
        }

        public IActionResult CreateCategoryPage()
        {
            return View("~/Views/Home/CreationPages/CreateCategoryPage.cshtml");
        }

        public IActionResult Categories()
        {
            return View("~/Views/Home/ListPages/Categories.cshtml", db.Categories);
        }

        /// <summary>
        /// ���������� ���� � ���� ������
        /// </summary>
        /// <param name="user">������������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateType(Models.Type type)
        {
            db.Types.Add(type);
            await db.SaveChangesAsync();
            return RedirectToAction("Types");
        }

        /// <summary>
        /// �������� ���� �� ���� ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteType(int? id)
        {
            if (id != null)
            {
                Models.Type type = new Models.Type { TypeID = id.Value };
                db.Entry(type).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Types");
            }
            return NotFound();
        }

        public IActionResult CreateTypePage()
        {
            return View("~/Views/Home/CreationPages/CreateTypePage.cshtml");
        }

        public IActionResult Types()
        {
            return View("~/Views/Home/ListPages/Types.cshtml", db.Types);
        }

        /// <summary>
        /// ���������� ���������� � ���� ������
        /// </summary>
        /// <param name="user">������������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            db.Transactions.Add(transaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Transactions");
        }
        public IActionResult CreateTransactionPage()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Types = db.Types.ToList();
            ViewBag.CurrentUser = 1;
            return View("~/Views/Home/CreationPages/CreateTransactionPage.cshtml");
        }

        public IActionResult Transactions()
        {
            var newVM = new IndexViewModel
            {
                Categories = db.Categories.ToList(),
                Types = db.Types.ToList(),
                Transactions = db.Transactions.ToList(),
                Users = db.Users.ToList()
            };
            return View("~/Views/Home/ListPages/Transactions.cshtml", newVM);
        }

    }
}
