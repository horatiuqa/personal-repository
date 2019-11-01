using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BankingApp
{
    public class DBContext
    {

        //string connectionString = @"Provider=SQLNCLI11.1;Integrated Security=SSPI;Persist Security Info=False;User ID="";Initial Catalog=LocalDataBase;Data Source=(LocalDB)\BankDB;Initial File Name="";Server SPN=""";
        //SqlConnection cnn;

        ////connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        //public void OpenDBConnection()
        //{
        //    string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        //    SqlConnection cnn;

        //}

        //public void CloseDBConnection()
        //{
        //    cnn = new SqlConnection(connectionString);
        //    cnn.Close();
        //}

        //public void CodVechi()
        //{

        //    //switch (option)
        //    //{
        //    //    case "1":

        //    //        SqlCommand cmd = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id = '1'", conn);
        //    //        SqlDataReader reader = cmd.ExecuteReader();
        //    //        while (reader.Read())
        //    //        {
        //    //            Console.WriteLine("Hello  {0}, your ID is: {1},and you have ${2} in you account", reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
        //    //        }
        //    //        Console.WriteLine("\n");
        //    //        Console.WriteLine("Press any key to continue....");
        //    //        Console.ReadLine();

        //    //        break;

        //    //    case "2":

        //    //        SqlCommand cmd1 = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id = '2'", conn);
        //    //        SqlDataReader reader1 = cmd1.ExecuteReader();
        //    //        while (reader1.Read())
        //    //        {
        //    //            Console.WriteLine("Hello  {0}, your ID is: {1},and you have ${2} in you account", reader1.GetString(0), reader1.GetString(1), reader1.GetInt32(2));
        //    //        }
        //    //        Console.WriteLine("\n");
        //    //        Console.WriteLine("Press any key to continue....");
        //    //        Console.ReadLine();

        //    //        break;

        //    //    case "3":

        //    //        SqlCommand cmd2 = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id = '3'", conn);
        //    //        SqlDataReader reader2 = cmd2.ExecuteReader();
        //    //        while (reader2.Read())
        //    //        {
        //    //            Console.WriteLine("Hello  {0}, your ID is: {1},and you have ${2} in you account", reader2.GetString(0), reader2.GetString(1), reader2.GetInt32(2));
        //    //        }
        //    //        Console.WriteLine("\n");
        //    //        Console.WriteLine("Press any key to continue....");
        //    //        Console.ReadLine();

        //    //        break;

        //    //    case "4":

        //    //        SqlCommand cmd3 = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id = '4'", conn);
        //    //        SqlDataReader reader3 = cmd3.ExecuteReader();
        //    //        while (reader3.Read())
        //    //        {
        //    //            Console.WriteLine("Hello  {0}, your ID is: {1},and you have ${2} in you account", reader3.GetString(0), reader3.GetString(1), reader3.GetInt32(2));
        //    //        }
        //    //        Console.WriteLine("\n");
        //    //        Console.WriteLine("Press any key to continue....");
        //    //        Console.ReadLine();

        //    //        break;

        //    //    case "5":

        //    //        SqlCommand cmd4 = new SqlCommand("SELECT UserName, UserID, Balance FROM [LocalDataBase].[dbo].[UserAccounts] WHERE Id = '5'", conn);
        //    //        SqlDataReader reader4 = cmd4.ExecuteReader();
        //    //        while (reader4.Read())
        //    //        {
        //    //            Console.WriteLine("Hello  {0}, your ID is: {1},and you have ${2} in you account", reader4.GetString(0), reader4.GetString(1), reader4.GetInt32(2));
        //    //        }
        //    //        Console.WriteLine("\n");
        //    //        Console.WriteLine("Press any key to continue....");
        //    //        Console.ReadLine();

        //    //        break;

        //    //    default:
        //    //        Console.WriteLine("User not recognized, please type more carefully!");
        //    //        break;

        //    //}
        //}


    }
}
