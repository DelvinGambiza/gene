using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace geneInsure.Models    
{    
    public class Transaction    
    {    
        public Transaction(int certificateNumber, int branchCode, string timeStamp, string customerName, string customerEmail, string customerContactNumber) 
        {
            this.certificateNumber = certificateNumber;
                this.branchCode = branchCode;
                this.timeStamp = timeStamp;
                this.customerName = customerName;
                this.customerEmail = customerEmail;
                this.customerContactNumber = customerContactNumber;
               
        }
                 
    }    
}