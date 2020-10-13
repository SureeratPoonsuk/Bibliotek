using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using uppgit_1_nr2;

namespace LibraryMvc.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            var db = new Database();
            var loans = db.GetLoans();

            return View(loans);
        }

        // GET: Loan/Details/5
        public ActionResult Details(string id)
        {
            var objectId = new ObjectId(id);

            var db = new Database();
            var loans = db.GetLoanById(objectId);
            return View(loans);
        }

        // Hämta ut alla Item, member och lägga till i Viewbag/ så vi kan använda i view
        // GET: Loan/Create
        public ActionResult Create()
        {
            var db = new Database();
            var items = db.GetItems();
            var members = db.GetMembers();


            var loanItems = items.Select(x => new SelectListItem    // till dropdown för att välja vilken item man vill låna. 
            {
                Value = x.Id.ToString(), // value vilken väder man välja i dropdownlista
                Text = x.Title // Text  = texter som ska visa i listan.
            });

            ViewBag.Item = loanItems;

            var membersItems = members.Select(x => new SelectListItem  // till dropdown för att välja vilken member som ska låna.
            {
                Value = x.Id.ToString(), 
                Text = x.Name
            });

            ViewBag.Member = membersItems;


            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var memberId = new ObjectId(collection["Member"]);
                var ItemId = new ObjectId(collection["Item"]);

                var db = new Database();
                var member = db.GetMemberById(memberId);
                var item = db.GetItemById(ItemId);

                var loanCount = db.GetLoansByItem(item); // hämta vi ut hur många av just artikel är lånare.

                if (loanCount >= item.TotalCount) // Om det inte finns någor ledigt så stopa vi. 
                {
                    //skicka till error för att visa att inte gå låna.
                    return RedirectToAction("Error", "Home");  // redirectoaction = skicka till Error sidan i homecontroller.
                }



                var start = DateTime.Now;
                var end = start.AddDays(14); // slut datum om 14 dagar.

                var loan = new Loan(member, item, start, end);

                db.CreateLoan(loan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      

        // GET: Loan/Delete/5
        public ActionResult Delete(string id)
        {
            var loan = new ObjectId(id);

            var db = new Database();
            db.DeleteLoanById(loan);

            return RedirectToAction(nameof(Index));

           
        }

       
    }
}