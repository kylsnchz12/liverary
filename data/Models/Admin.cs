using System;

namespace liverary.data.Models
{
    public class Admin
    {
        public int AId { get; set; }

        public string name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; } // Consider using a secure method to store passwords

       
    }
}
