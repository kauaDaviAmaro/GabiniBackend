namespace Core.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced
    }

    public enum Scholarship
    {
        Fundamental,
        HighSchool,
        HigherEducation
    }

    public class User
    {
        public string Id { get; set; }
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

        private User() { }

        public User(string id, string name, string userName, string email, string phone, string birthDate, Gender gender, string cPF, MaritalStatus maritalStatus, Scholarship scholarship, string password)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Gender = gender;
            CPF = cPF;
            MaritalStatus = maritalStatus;
            Scholarship = scholarship;
            Password = password;
        }
    }
}
