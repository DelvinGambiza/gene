using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using geneInsure.Models;  
  
namespace geneInsure.Controllers  
{  
    public class TransactionController : Controller  
    {  
        TransactionDataAccessLayer objtransaction = new TransactionDataAccessLayer();  
  
        public IActionResult Index()  
        {  
            List<Transaction> lstTransaction = new List<Transaction>();  
            lstTransaction = objtransaction.GetAllTransactions().ToList();  
  
            return View(lstTransaction);  
        }  
     }  
}


//Save transaction data
[HttpGet]  
public IActionResult Create()  
{  
    return View();  
}  
  
[HttpPost]  
[ValidateAntiForgeryToken]  
public IActionResult Create([Bind] Transaction transaction)  
{  
    if (ModelState.IsValid)  
    {  
        objtransaction.AddTransaction(transaction);  
        return RedirectToAction("Index");  
    }  
    return View(transaction);  
} 

//Retrieve transaction data
[HttpGet]  
public IActionResult Details(int? certificateNumber)  
{  
    if (certificateNumber == null)  
    {  
        return NotFound();  
    }  
    Transaction transaction = objtransaction.GetTransactionData(certificateNumber);  
  
    if (transaction == null)  
    {  
        return NotFound();  
    }  
    return View(transaction);  
}  