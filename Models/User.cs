using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServer.Models
{
    public class User
    {
        //This is the model for the User that corresponds to the User table in the database
        public string User_ID { get; set; }

        public String UserName { get; set; }

        public String UserEmail { get; set; }

        public String Description { get; set; }

    }
}