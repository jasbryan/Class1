using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassApp1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankWebUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly BankModel _context;

        public AccountsController(BankModel context)
        {
            _context = context;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            //return View(await _context.Accounts.ToListAsync());
            return View(Bank.GetAllAccounts(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var account = await _context.Accounts
            //    .FirstOrDefaultAsync(m => m.AccountNumber == id);

            var account = Bank.GetAccountDetails(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmailAddress,AccountType")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.EmailAddress, account.AccountType);
                //_context.Add(account);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountDetails(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AccountNumber,EmailAddress,Balance,AccountType,CreatedDate")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Bank.EditAccount(account);
                    //_context.Update(account);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Bank.AccountExists(account.AccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountDetails(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bank.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountDetails(id.Value);
            return View(account);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(IFormCollection formData)
        {
            var accountNumber = Convert.ToInt32(formData["AccountNumber"]);
            var amount = Convert.ToDecimal(formData["Amount"]);

            Bank.Deposit(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountDetails(id.Value);
            return View(account);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(IFormCollection formData)
        {
            var accountNumber = Convert.ToInt32(formData["AccountNumber"]);
            var amount = Convert.ToDecimal(formData["Amount"]);

            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transactions(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var transactions = Bank.GetAllTransactions(id.Value);
            return View(transactions);
        }
    }
}
