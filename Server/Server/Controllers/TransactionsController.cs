using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DTO;

namespace Server.Controllers
{
    public class TransactionsController : Controller
    {
        private CibitDb  _db;

        public TransactionsController(CibitDb db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region APi
        public async Task<IActionResult> getAll(string id)
        {
            return Json(new { data = await _db.Transactions.Select(t => new TransactionDTO
            {
                TransactionId = t.TransactionId,
                ReciverId = t.ReciverId,
                SenderId = t.SenderId,
                amount = t.amount,
                coins = t.}).Where(tr => tr.SenderId == id || tr.ReciverId == id).ToListAsync() 
            });
        }
        #endregion
    }
}