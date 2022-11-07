

namespace HalBookstore.Entity
{
    public class SoldProduct
    {
        private int iD;
        private int id_Product;
        private string iD_BILL;
        private string product;
        private int price;
        private int amount;
        private int deal;
        private int total;
        private string create_at;
        private int sum_amount = 0;

        public int ID { get => iD; set => iD = value; }
        public string Product { get => product; set => product = value; }
        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Deal { get => deal; set => deal = value; }
        public int Total { get => total; set => total = value; }
        public string Create_at { get => create_at; set => create_at = value; }
        public int Sum_amount { get => sum_amount; set => sum_amount = value; }
        public string ID_BILL { get => iD_BILL; set => iD_BILL = value; }
        public int Id_Product { get => id_Product; set => id_Product = value; }

        public SoldProduct() { }
        public SoldProduct(string Product, int Total, int Sum_amount)
        {
            this.Product = Product;
            this.Total = Total;
            this.Sum_amount = Sum_amount;
        }
        public SoldProduct(int iD, int id_pro, string id_bill, string product, int price, int amount, int deal, int total, string create_at)
        {
            ID = iD;
            id_Product = id_pro;
            ID_BILL = id_bill;
            Product = product;
            Price = price;
            Amount = amount;
            Deal = deal;
            Total = total;
            Create_at = create_at;
        }
    }
}
