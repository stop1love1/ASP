

namespace HalBookstore.Entity
{
    public class Account
    {
        private int iD;
        private string username;
        private string password;
        private string name;
        private int isStaff;
        private int isAdmin;
        private string maBaoMat;
        private string create_at;
        private string update_at;

        public int ID { get => iD; set => iD = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int IsStaff { get => isStaff; set => isStaff = value; }
        public int IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string MaBaoMat { get => maBaoMat; set => maBaoMat = value; }
        public string Create_at { get => create_at; set => create_at = value; }
        public string Update_at { get => update_at; set => update_at = value; }
        public string Name { get => name; set => name = value; }

        public Account() { }
        public Account(int iD, string username, string password, string name, string maBaoMat, int isStaff, int isAdmin, string create_at, string update_at)
        {
            ID = iD;
            Username = username;
            Password = password;
            Name = name;
            IsStaff = isStaff;
            IsAdmin = isAdmin;
            MaBaoMat = maBaoMat;
            Create_at = create_at;
            Update_at = update_at;
        }
    }
}
