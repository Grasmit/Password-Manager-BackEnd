using demo.Model;

namespace demo
{
    public interface IItemRepository
    {
        public List<Item> GetItems();

        public List<Item> AddUser(Item item);

        public Item GetUser(int id);

        public bool DeleteUser(int id);

        public Item UpdateUser(Item item);

        
    }
}
