using System.Collections.Generic;

namespace sga.API.Domain.Models
{

    // This is the model for the user object
    public class User
    {

        public int User_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}