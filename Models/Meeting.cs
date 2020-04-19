using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServer.Models
{
    public class Meeting
    {
        public int Meeting_ID { get; set; }

        public DateTime MeetingTime { get; set; }

        public int Lattitude { get; set; }

        public int Longitude { get; set; }

        public int MeetingNum { get; set; }

        public string Minutes { get; set; }


    }
}