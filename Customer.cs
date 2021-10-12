using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6D2_Bank_System_Avinash
{
    class Customer
    {
        public string customer_id { get; private set; } //private set so that no one can set it from outside
        public string customer_name { get; private set; }
        public string account_number { get; private set; }
        public double account_balance { get;  set; }         // want it to be modified
        public string cheque_book_number { get; private set; }
                public bool loan_applied { get; set; }      // want it to be modified

        public Customer(string id, string name, string account_no, string cheque_bk_no)     //create constructor
        {
            customer_id = id;
            customer_name = name;
            account_number = account_no;
            account_balance = 0;
            cheque_book_number = cheque_bk_no;
            loan_applied = false;
        }

        public Customer(string id, string name, string account_no, string cheque_bk_no, double bal, bool loan_app)
        {
            customer_id = id;
            customer_name = name;
            account_number = account_no;
            account_balance = bal;
            cheque_book_number = cheque_bk_no;
            loan_applied = loan_app;
        }

        public override string ToString()
        {
            return customer_id + " " + customer_name + " " + account_balance + " " + account_number + " " + cheque_book_number + " " + loan_applied;
        }



    }
}
