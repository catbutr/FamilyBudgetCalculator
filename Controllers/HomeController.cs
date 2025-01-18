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
        /// Добавление пользователя в базу данных
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(db.Users);
        }

        /// <summary>
        /// Удаление пользователя из базы данных
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
        /// GET-версия редактирования пользователя
        /// </summary>
        /// <param name="id">id пользователя в базе данных</param>
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
        /// POST-версия редактирование пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        /// <summary>
        /// Добавление категории в базу данных
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Удаление категории из базы данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category? category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryID == id);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Добавление типа в базу данных
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateType(Models.Type type)
        {
            db.Types.Add(type);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Удаление типа из базы данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteType(int? id)
        {
            if (id != null)
            {
                Models.Type? type = await db.Types.FirstOrDefaultAsync(p => p.TypeID == id);
                if (type != null)
                {
                    db.Types.Remove(type);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Добавление трансакции в базу данных
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            db.Transactions.Add(transaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
