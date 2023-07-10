namespace File_Professor_Management.Models
{
    public class AddProfessorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Lisence { get; set; }
        public string PhoneNumber { get; set; }
    }
}
