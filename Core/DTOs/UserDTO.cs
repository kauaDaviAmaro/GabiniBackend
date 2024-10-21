using Core.Models;

namespace Core.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string CPF { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Scholarship Scholarship { get; set; }
        public string Password { get; set; }
    }
}
