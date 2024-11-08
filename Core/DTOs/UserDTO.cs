using Core.Models;

namespace Core.DTOs
{
    public class UserDTO
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string birthDate { get; set; }
        public Gender gender { get; set; }
        public string cpf { get; set; }
        public MaritalStatus maritalStatus { get; set; }
        public Scholarship scholarship { get; set; }
        public string password { get; set; }

        public UserDTO(string name, string userName, string email, string phone, string birthDate, Gender gender, string cpf, MaritalStatus maritalStatus, Scholarship scholarship, string password)
        {
            this.name = name;
            this.userName = userName;
            this.email = email;
            this.phone = phone;
            this.birthDate = birthDate;
            this.gender = gender;
            this.cpf = cpf;
            this.maritalStatus = maritalStatus;
            this.scholarship = scholarship;
            this.password = password;
        }
    }
}
