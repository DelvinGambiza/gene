using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace geneInsure.Models    
{    
    public class Branch
    {    
        public Branch(int branchCode, string branchName) 
        {
            this.branchCode = branchCode;
            this.branchName = branchName;
               
        }
                 
    }    
}