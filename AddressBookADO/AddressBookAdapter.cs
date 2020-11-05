using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
   public class AddressBookAdapter
    {
        public static string connectionString = "Server=(localdb)\\MSSQLLocalDB; Initial Catalog =address_book_service; User ID = AkSharma; Password=abhishek123";
       public SqlConnection connection = new SqlConnection(connectionString);
     /// Function to create table 
        public bool CreateTable() {
            string query = @"CREATE TABLE dbo.Address_Model
                (
                    first_name varchar(30),
                    last_name varchar(30),
                    address varchar(30),
                    city varchar(20),
                    state varchar(20),
                    zip int,
                    phone float,
                    emailid varchar(30)
                );";
            SqlCommand command = new SqlCommand(query, this.connection);
            
            try
            {
               this.connection.Open();
              int numberOfExecutedRows=command.ExecuteNonQuery();

                if (numberOfExecutedRows != 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
               this.connection.Close();
                
            }
        }
    }
    }

