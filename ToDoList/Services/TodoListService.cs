using System.Collections.Generic;
using ToDoList.Models;
using ToDoList.Utils;

namespace ToDoList.Services
{
    public class TodoListService : ITodoListService
    {
        public bool AddItem(Item item)
        {
            DbUtil.DBConnection();

            return true;
        }
        public bool RemoveItem() { return true; }
        public bool ModifyItem() { return true; }
        public Item GetItem() { return new Item(); }
        public List<Item> GetItems() { return new List<Item>(); }
        public bool GetItemsByPriority() { return true; }
    }
}
