using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTServer.Models;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;


namespace RESTServer
{
    public class UserPersistence
    {

        private SqlConnection conn;

        public UserPersistence()
        {
            string myConnectionString;
            myConnectionString = "server=sga-server.database.windows.net;uid=sga-server;pwd=Password1!;database=SGA-Database-MarkV";
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public User getUser(string ID)
        {
            User u = new User();
            SqlDataReader mySQLReader = null;
            String sqlString = "SELECT * FROM Users WHERE ID = " + ID.ToString();
            SqlCommand cmd = new SqlCommand(sqlString, conn);

            mySQLReader = cmd.ExecuteReader();
            if (mySQLReader.Read())
            {
                u.User_ID = mySQLReader.GetString(0);
                u.UserName = mySQLReader.GetString(1);
                u.Description = mySQLReader.GetString(2);
                return u;
            }
            else
            {
                return null;
            }
        }

        public string saveUser(User userToSave)
        {
            String sqlString = "INSERT INTO USERS (UserName, UserEmail, Description) VALUES ('" + userToSave.UserName + "', '" + userToSave.UserEmail + "', '" + userToSave.Description + "'); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
      
            string id = (string)cmd.ExecuteScalar();
            return id;
        }

    }
}