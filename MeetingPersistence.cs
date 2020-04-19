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
    public class MeetingPersistence
    {
        private SqlConnection conn;

        public MeetingPersistence()
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

        public Meeting getMeeting(int ID)
        {
            Meeting m = new Meeting();
            SqlDataReader mySQLReader = null;
            String sqlString = "SELECT * FROM MEETING WHERE ID = " + ID.ToString();
            SqlCommand cmd = new SqlCommand(sqlString, conn);

            mySQLReader = cmd.ExecuteReader();
            if (mySQLReader.Read())
            {
                m.Meeting_ID = mySQLReader.GetInt32(0);
                m.MeetingTime = mySQLReader.GetDateTime(1);
                m.Lattitude = mySQLReader.GetInt32(2);
                m.Longitude = mySQLReader.GetInt32(3);
                m.MeetingNum = mySQLReader.GetInt32(4);
                m.Minutes = mySQLReader.GetString(5);
                return m;
            }
            else
            {
                return null;
            }
        }

        public int saveMeeting(Meeting meetingToSave)
        {
            String sqlString = "INSERT INTO MEETING (MeetingTime, Lattitude, Longitude, MeetingNum, Minutes) VALUES ('" + meetingToSave.MeetingTime + "', '" + meetingToSave.Lattitude + "', '" + meetingToSave.Longitude + "', '" + meetingToSave.MeetingNum + "', '" + meetingToSave.Minutes + "'); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sqlString, conn);

            int id = (int)cmd.ExecuteScalar();
            return id;
        }

    }
}
