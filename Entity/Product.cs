
namespace HalBookstore.Entity
{
    public class Product
    {
        private int id;
        private string name;
        private string image;
        private int price;
        private int amount;
        private int category;
        private string create_at;
        private string updated_at;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Create_at { get => create_at; set => create_at = value; }
        public string Updated_at { get => updated_at; set => updated_at = value; }
        public int Category { get => category; set => category = value; }

        public Product() { }
        public Product(int id, string name, string image, int price, int amount, int category, string create_at, string updated_at)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            Amount = amount;
            this.category = category;
            Create_at = create_at;
            Updated_at = updated_at;
        }
        public string toString()
        {
            return $"Product(Id={id}, Name={Name}), Price={Price}";
        }
    }
}
