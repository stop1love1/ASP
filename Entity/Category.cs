

namespace HalBookstore.Entity
{
    public class Category
    {
        private int id;
        private string name;

        public Category() { }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
