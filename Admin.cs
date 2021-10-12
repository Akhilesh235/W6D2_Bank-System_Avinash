using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6D2_Bank_System_Avinash
{
    class Admin
    {
        Dictionary<string, Customer> dictionaryOfCustomer = new Dictionary<string, Customer>(); //why using dict instead of List --> because dict has key and value and u can just update through key

        public Admin()
        {
            if(!File.Exists("Banking_Details.txt"))
            {
                Console.WriteLine("!!!! No Previous Data Exist !!!!");
                return;
            }
            
            FileStream fs = new FileStream("Banking_Details.txt", FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs);

            string str = sr.ReadLine();
            while(str != null)
            {
                var strarr = str.Split('_');
                var account_bal = double.Parse(strarr[3]);
                var loan_applied = bool.Parse(strarr[5]);
                var customer = new Customer(strarr[0], strarr[1], strarr[2], strarr[4], account_bal, loan_applied); //create object from string array
                if(!dictionaryOfCustomer.ContainsKey(strarr[0]))
                {
                    dictionaryOfCustomer.Add(strarr[0], customer);
                }

                str = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }
            
        public void PerformOperation()
        {
            bool user_exited = false;
            while(!user_exited)
            {
                Console.WriteLine("Select Option");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Withdraw amount");
                Console.WriteLine("4. Exit");
                int user_option = int.Parse(Console.ReadLine());

                switch (user_option)
                {
                    case 1:
                        {
                            var new_cust = HandleAccountOpening.CreateCustomerAccount();
                            if (new_cust!= null)
                            {
                                if (!dictionaryOfCustomer.ContainsKey(new_cust.customer_id))
                                {
                                    dictionaryOfCustomer.Add(new_cust.customer_id, new_cust);
                                }
                                else
                                {
                                    Console.WriteLine("Acct already exists");
                                }
                            }
                            else
                            {
                                Console.WriteLine("customer creation failed.Try again");
                            }
                            break;
                        }

                    case 2:
                        {
                            var user_id = Console.ReadLine();
                            dictionaryOfCustomer[customer_id];
                            Handle_Withdraw_Transaction.HandleWithdraw(customer);
                            dictionaryOfCustomer[customer_id] = customer;
                            break;
                        }

                    case 4:
                        {
                            WriteAllTransactionInFile();
                            user_exited = true;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void WriteAllTransactionInFile()
        {
            throw new NotImplementedException();
            //overwrite existing file
            // write content of dict in file
        }
    }
}
