using System.ComponentModel.DataAnnotations;

namespace project_admin.Models
{
    public class AddUserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}