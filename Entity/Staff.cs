

namespace HalBookstore.Entity
{
    public class Staff
    {
        private int id;
        private string name;
        private string gender = "Nam";
        private string birthday = "Null";
        private string country = "Null";
        private string numberPhone = "Null";
        private string email = "Null";
        private string start_day_work = "Null";
        private string username;
        private string note = "Null";

        public Staff() { }
        public Staff(int id, string name, string gender, string birthday, string country, string numberphone, string email, string day, string username, string note)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Country = country;
            NumberPhone = numberphone;
            Email = email;
            Start_day_work = day;
            Username = username;
            Note = note;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Country { get => country; set => country = value; }
        public string NumberPhone { get => numberPhone; set => numberPhone = value; }
        public string Email { get => email; set => email = value; }
        public string Start_day_work { get => start_day_work; set => start_day_work = value; }
        public string Username { get => username; set => username = value; }
        public string Note { get => note; set => note = value; }
    }
}
