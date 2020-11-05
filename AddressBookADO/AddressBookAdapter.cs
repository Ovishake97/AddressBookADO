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
        public string AddAddress(AddressBookModel model) {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("sp.InsertValues", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.firstName);
                    command.Parameters.AddWithValue("@last_name",model.lastName);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phone", model.phone);
                    command.Parameters.AddWithValue("@emailid", model.emailid);
                    return "Added succesfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }

