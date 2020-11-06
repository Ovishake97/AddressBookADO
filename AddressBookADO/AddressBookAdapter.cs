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
        public bool CreateTable()
        {
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
                int numberOfExecutedRows = command.ExecuteNonQuery();

                if (numberOfExecutedRows != 0)
                {
                    return true;
                }
                else
                {
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
        /// Method defined to add data and on adding
        /// returns success message
        public string AddAddress(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("dbo.AddressBookHandilng", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.firstName);
                    command.Parameters.AddWithValue("@last_name", model.lastName);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phone", model.phone);
                    command.Parameters.AddWithValue("@emailid", model.emailid);
                    command.ExecuteNonQuery();
                    return "Added succesfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///Method defined to edit the table accordingly by passing any query 
        ///and returning true if any number of rows are affected
        public bool UpdateTable(string query)
        {
            using (this.connection)
            {
                try
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand(query,this.connection);
                    int numberOfEffectedRows = command.ExecuteNonQuery();
                    if (numberOfEffectedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        /// Accepts query as a parameter and returns the list of the people
        /// satisfying the particular query
        public List<string> GetPersons(string query)
        {
            List<string> records = new List<string>();
            AddressBookModel model = new AddressBookModel();
            using (connection)
            {
                try
                {
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        this.connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.firstName = reader.GetString(0);
                                records.Add(model.firstName);
                            }
                            reader.Close();
                            return records;
                        }
                        else
                        {
                            throw new Exception("Invalid query");
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    this.connection.Close();
                }


            }
        }
    }
}
