

namespace HalBookstore.Entity
{
    public class DTNV
    {
        private int iD;
        private string name;
        private string username;
        private int count_Bill;
        private int sum_total;
        public DTNV(int id, string name, string username, int count, int sum)
        {
            this.ID = id;
            this.Name = name;
            Username = username;
            Count_Bill = count;
            Sum_total = sum;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public int Count_Bill { get => count_Bill; set => count_Bill = value; }
        public int Sum_total { get => sum_total; set => sum_total = value; }

        public string toString()
        {
            return $"ID={ID}, Name={Name}, Username={username}, Amount={Count_Bill}, Sum_Total={Sum_total}";
        }
    }
}
