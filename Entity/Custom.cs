

namespace HalBookstore.Entity
{
    public class Custom
    {
        private string id;
        private string name;
        private string gender;
        private string address;
        private string phone;
        private string bill;
        private string username;
        private string note;
        public Custom() { }
        public Custom(string id, string name, string gender, string address, string phone, string bill, string username, string note)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Address = address;
            Phone = phone;
            Bill = bill;
            Username = username;
            Note = note;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Bill { get => bill; set => bill = value; }
        public string Username { get => username; set => username = value; }
        public string Note { get => note; set => note = value; }
    }
}
