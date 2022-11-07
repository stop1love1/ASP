

using System.Collections.Generic;

namespace HalBookstore.Entity
{
    public class Bill
    {
        private string iD;
        private int idStaff;
        private string staff;
        private string custom;
        private string product = null;
        private int price = 0;
        private int amount = 0;
        private int deal = 0;
        private long total = 0;
        private string create_at;
        private long tongTien = 0;
        private long tienKhachTra = 0;
        private long tienThua = 0;
        private List<Bill> list;

        private int id_Product;
        public string ID { get => iD; set => iD = value; }
        public int IdStaff { get => idStaff; set => idStaff = value; }
        public string Staff { get => staff; set => staff = value; }
        public string Custom { get => custom; set => custom = value; }
        public string Product { get => product; set => product = value; }
        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Deal { get => deal; set => deal = value; }
        public long Total { get => total; set => total = value; }
        public string Create_at { get => create_at; set => create_at = value; }
        public long TongTien { get => tongTien; set => tongTien = value; }
        public long TienKhachTra { get => tienKhachTra; set => tienKhachTra = value; }
        public long TienThua { get => tienThua; set => tienThua = value; }
        public List<Bill> List { get => list; set => list = value; }
        public int Id_Product { get => id_Product; set => id_Product = value; }

        public Bill() { }
        public Bill(int id_p, string product, int price, int amount, int total)
        {
            id_Product = id_p;
            this.product = product;
            this.price = price;
            this.amount = amount;
            this.total = Price_Of_Product();
        }
        public Bill(string id, int idStaff, string staff, string custom, int tongtien, int tienkhachtra, int tienthua, string create_at)
        {
            iD = id;
            this.idStaff = idStaff;
            this.staff = staff;
            this.custom = custom;
            total = tongtien;
            tienKhachTra = tienkhachtra;
            tienThua = tienthua;
            this.create_at = create_at;
        }
        public Bill(string ID, int idStaff, string Staff, string Custom, string Product, int Price, int Amount, int Deal, List<Bill> list, long TienKhachTra, string Create_at)
        {
            iD = ID;
            this.idStaff = idStaff;
            staff = Staff;
            custom = Custom;
            product = Product;
            price = Price;
            amount = Amount;
            deal = Deal;
            total = Price * Amount - Deal;
            create_at = Create_at;
            this.list = List;
            tongTien = TinhTongTien(list);
            tienKhachTra = TienKhachTra;
            tienThua = TienKhachTra - TongTien;
        }
        public long Price_Of_Product()
        {
            return Price * Amount - Deal;
        }
        public long TinhTongTien(List<Bill> list)
        {
            long sum = 0;
            if (list.Count != 0)
            {
                foreach (Bill bill in list)
                {
                    sum += bill.Total;
                }
            }
            return sum;
        }
    }
}
