using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace ExpenseManagement.Controllers
{
    public class DashboardController : Controller
    {
        public readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endtDate = DateTime.Today;

            List<Transaction> selectedTransactions = await _context.Transactions.Include(x => x.Category)
                .Where(y => y.Date >= startDate && y.Date <= endtDate).ToListAsync();

            int totalIncome = selectedTransactions.Where(x => x.Category.Type.ToLower() == "income").Sum(y => y.Amount);
            ViewBag.TotalIncome = totalIncome.ToString("C0");
            int totalExpense = selectedTransactions.Where(x => x.Category.Type.ToLower() == "expense").Sum(y => y.Amount);
            ViewBag.TotalExpense=totalExpense.ToString("C0");
            int balance = totalIncome - totalExpense;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Balance = String.Format(culture,"{0:C0}", balance);
            return View();
        }
    }
}
