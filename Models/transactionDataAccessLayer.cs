using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace Transaction.Models    
{    
    public class TransactionDataAccessLayer    
    {    
        string connectionString = "Your Connection String";    
    
        //To View all employees details      
        public IEnumerable<Transaction> GetAllTransactions()    
        {    
            List<Transaction> lsttransaction = new List<Transaction>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllTransactions", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Transaction transaction = new Transaction();    
                    
                    transaction.branchCode = Convert.ToInt32(rdr["branchCode"]);;
                    transaction.certificateNumber = Convert.ToInt32(rdr["certificateNumber"]);    
                    transaction.customerName = rdr["Name"].ToString();    
                    transaction.customerEmail = rdr["Gender"].ToString();    
                    transaction.customerContactNumber = rdr["Department"].ToString();      
    
                    lsttransaction.Add(transaction);    
                }    
                con.Close();    
            }    
            return lsttransaction;    
        }    
    
        //To Add new transaction record      
        public void AddTransaction(Transaction transaction)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddTransaction", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@certificateNumber", transaction.certificateNumber);    
                cmd.Parameters.AddWithValue("@branchCode", transaction.branchCode);    
                cmd.Parameters.AddWithValue("@customerName", transaction.customerName);    
                cmd.Parameters.AddWithValue("@customerEmail", transaction.customerEmail); 
                cmd.Parameters.AddWithValue("@customerContactNumber", transaction.customerContactNumber);  
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    

    
        //Get the details of a particular employee    
        public Transaction GetTransactionData(int? certificateNumber)    
        {    
            Transaction transaction = new Transaction();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM tblTransaction WHERE certificateNumber= " + certificateNumber;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    transaction.certificateNumber = Convert.ToInt32(rdr["certificateNumber"]); 
                    transaction.branchCode = Convert.ToInt32(rdr["branchCode"]);   
                    transaction.customerName = rdr["customerName"].ToString();    
                    transaction.customerEmail = rdr["customerEmail"].ToString();    
                    transaction.customerContactNumber = rdr["customerContactNumber"].ToString(); 
                     
                }    
            }    
            return transaction;    
        }    
    
        
    }    
}    