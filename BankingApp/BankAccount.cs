using System;
using System.Data.SqlClient;

namespace BankingApp
{
    public class BankAccount
    {
        int balance;
        int lastTransaction;
        //readonly string customerName;                                   //constructor params
        //readonly string customerID;
        int userId;

        //public BankAccount(string cName, string cID)                     //constructor 
        //{
        //    customerName = cName;
        //    customerID = cID;
        //}
        public void StartNewTransaction()
        {
            SelectUser();
            ShowMenu();
        }
        public int SelectUser()
        {
            var conn = OpenDBConnection();      //metoda care deschide conexiunea la DB

            string sql = "Select Id, UserName from [LocalDataBase].[dbo].[UserAccounts] order by Id asc";         //stringul care face query
            SqlCommand cmdX = new SqlCommand(sql, conn);          //creez un obiect 'cmdX' de tip SqlCommand //
            cmdX.ExecuteNonQuery();                                 //apelez metoda ExecuteQuery cu obiectuil cmdX
            SqlDataReader readerX = cmdX.ExecuteReader();           //pun in variabila 'readerX' de tip SqlDataReader ce rezulta din cmdX.EsecuteReader
            Console.WriteLine("********************************************");
            while (readerX.Read())                                                
            {
                Console.WriteLine("{0}. {1}", readerX.GetInt32(0), readerX.GetString(1));                 //navighez prin datele aduse din DB || pt fiecare set de date printez asta
            }
            readerX.Close();                       // inchid readerul
            Console.WriteLine("********************************************");
            Console.WriteLine("Please select your account ...");

            var option = Console.ReadLine();                            // pun in variabila 'option' inputul pe care il dau din tastatura prin comanda Console.ReadLine()
            var id = option;                                            //creez o variabila noua 'id' la care ii asignez valoarea din optiion
            userId = Convert.ToInt32(id);                               //asignez valoarea din 'id' variabilei 'userId' dupa ce o convertesc in Int32

            SqlCommand command = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id =@ID", conn);    //  creez comanda prin care fac query nou cu ID parametrizat
            SqlParameter iDparameter = new SqlParameter();                               //declar parametrul
            iDparameter.ParameterName = "@ID";                                             //declar numele (@ID din query de sus)
            iDparameter.Value = userId;                                                    //ii asignez valoarea lui 'userId'
            command.Parameters.Add(iDparameter);                                            //il adaug la query
            command.ExecuteNonQuery();                                                       //execut query                                       
            SqlDataReader reader = command.ExecuteReader();                                 // pun rezultatul in variabila reader de tip SqlDataReader
            while (reader.Read())
            {                                                                                      //afisez datele din DB
                Console.WriteLine("Hello {0}, your ID is {1} and you have ${2} in your account.", reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
            }
            return userId;                                                          //returnez userId
        }

        public void ShowMenu()
        {
            char option;                                           //declar variabila 'option' cu care fac switch la cases

            //Console.WriteLine("Hello Mr. " + customerName);                                //erau folosite in constructor
            //Console.WriteLine("Your customer ID is: " + customerID);
            Console.WriteLine("\n");
            Console.WriteLine("a. Check Balance");
            Console.WriteLine("b. Withdraw money");
            Console.WriteLine("c. Deposit money");
            Console.WriteLine("d. Check previous transaction");
            Console.WriteLine("e. Exit");

            do
            {
                Console.WriteLine("===========================================================");
                Console.Write("Select an option from the menu: ");
                string optiune = Console.ReadLine();    //pun inputul de la tastatura intr-o variabila 'optiune'
                option = Convert.ToChar(optiune);       //convertesc din string in char variabila 'optiune' si o pun in variabila 'option'
                Console.WriteLine("===========================================================");
                Console.WriteLine("\n");

                switch (option)               //in functie de inputul salvat in 'option', merge pe case-ul aferent
                {

                    case 'a':

                        Console.WriteLine("---------------------------------------------------");
                        CheckBalance();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("\n");
                        break;

                    case 'b':

                        string amount;            //declar variabila 'amount'
                        Console.WriteLine("---------------------------------------------------");
                        Console.Write("Type in the amount to withdraw: ");
                        Console.WriteLine("---------------------------------------------------");
                        amount = Console.ReadLine();   //pun inputul din tastatura in variabila 'amount'
                        //int val = Convert.ToInt32(amount); //convertesc inputul in 'int32' si il pun in variabila 'val'

                        //convert cu try parse
                        if(int.TryParse(amount, out var val))
                        {
                            Withdraw(val);    //apelez metoda 'withdraw' cu valoarea din 'val'
                            Console.WriteLine("You have successfully withdrawn " + "$" + val + " from your account");
                            Console.WriteLine("\n");
                        }
                        else
                            Console.WriteLine("Invalid Value Selected");
                        //gata convert cu try parse

                        //Withdraw(val);    //apelez metoda 'withdraw' cu valoarea din 'val'
                        //Console.WriteLine("You have successfully withdrawn " + "$" + val + " from your account");
                        //Console.WriteLine("\n");
                        break;

                    case 'c':

                        string amount2;
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Type in the amount to deposit: ");
                        Console.WriteLine("---------------------------------------------------");
                        amount2 = Console.ReadLine();
                        int val2 = Convert.ToInt32(amount2);
                        Deposit(val2);
                        Console.WriteLine("You have successfully deposited " + "$" + val2 + " to your account");
                        Console.WriteLine("\n");
                        break;

                    case 'd':

                        Console.WriteLine("---------------------------------------------------");
                        CheckPreviousTransaction();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("\n");
                        break;

                    case 'e':
                        Console.WriteLine("***************************************************");
                        break;

                    default:
                        Console.WriteLine("You entered an invalid option! Please select more carefully");
                        break;

                }
            }
            while (option != 'e');

            Console.WriteLine("Thank you for using Hori's Banking Services");
        }

        public void Deposit(int amount)
        {
            var conn = OpenDBConnection();

            SqlCommand cmd = new SqlCommand("SELECT Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id =@ID", conn);


            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = userId;
            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                 balance = reader.GetInt32(0);
            }
            
            if (amount != 0)
            {
                balance += amount;
                lastTransaction = amount;
            }

            SqlCommand cmd2 = new SqlCommand("UPDATE [LocalDataBase].[dbo].[UserAccounts] set Balance =" + balance + "WHERE Id = @ID", conn);
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@ID";
            param2.Value = userId;
            cmd2.Parameters.Add(param2);
            reader.Close();
            cmd2.ExecuteNonQuery();
        }

        public void Withdraw(int amount)
        {
            var conn = OpenDBConnection();

            string sql = "SELECT Balance FROM  [LocalDataBase].[dbo].[UserAccounts] WHERE Id =" + userId;
            SqlCommand cmd = new SqlCommand(sql, conn);
            balance = (int)cmd.ExecuteScalar();

            if (amount != 0)
            {
                balance -= amount;
                lastTransaction = -amount;
            }

            string sql2 = "UPDATE [LocalDataBase].[dbo].[UserAccounts] set Balance=" + balance + "WHERE Id =" + userId;
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.ExecuteScalar();


        }

        public void CheckBalance()
        {

            var conn = OpenDBConnection();

            string sql = "SELECT Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id =" + userId;
            SqlCommand cmd = new SqlCommand(sql, conn);

            balance = (int)cmd.ExecuteScalar();
            Console.WriteLine("Your current balance is: " + "$" + balance);
            
        }

        public void CheckPreviousTransaction()
        {
            var conn = OpenDBConnection();

            string sql = "UPDATE [LocalDataBase].[dbo].[UserAccounts] set LastTransaction=" + lastTransaction +  " WHERE Id =" + userId;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteScalar();

            if (lastTransaction > 0)
            {
                Console.WriteLine("On your last transaction you've Deposited: " + "$" + lastTransaction);
            }
            else if(lastTransaction < 0)
            {
                Console.WriteLine("On your last transaction you've Withdrawn: " + "$" + lastTransaction);
            }
            else
                Console.WriteLine("No recent transactions occured");
        }

        public SqlConnection OpenDBConnection()
        {
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LocalDataBase;Data Source=(LocalDB)\BankDB");
            conn.Open();
            return conn;
        }

        public void CreateNewAccount()
        {

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type the user ID ...");
            Console.WriteLine("--------------------------------------");
            var id = Console.ReadLine();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type the full user name ...");
            Console.WriteLine("--------------------------------------");
            var name = Console.ReadLine();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type the current balance ...");
            Console.WriteLine("--------------------------------------");
            var balance = Console.ReadLine();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type the last transaction  ...");
            Console.WriteLine("--------------------------------------");
            var transaction = Console.ReadLine();

            
            var conn = OpenDBConnection();

            string sql = "INSERT into [LocalDataBase].[dbo].[UserAccounts]" +
                            "values(@UserID,@UserName,@Balance,@LastTransaction)";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID";
            param.Value = id;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@UserName";
            param2.Value = name;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@Balance";
            param3.Value = balance;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@LastTransaction";
            param4.Value = transaction;

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);

            cmd.ExecuteNonQuery();

            Console.WriteLine("*************************************");
            Console.WriteLine("An account for user "+ name + " was successfully created");
            Console.WriteLine("*************************************");

            SelectOption();

        }

        public void SelectOption()
        {
            Console.WriteLine("==================***==================");
            Console.WriteLine("1. Start Transactions");
            Console.WriteLine("2. Create a new account");
            Console.WriteLine("==================***==================");
            Console.WriteLine("Select one of the above ...");
            Console.WriteLine("_______________________________________");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StartNewTransaction();
                    break;

                case "2":
                    CreateNewAccount();
                    break;

                default:
                    Console.WriteLine("Something went wrong ... please select again");
                    break;
            }
        }
    }
}
