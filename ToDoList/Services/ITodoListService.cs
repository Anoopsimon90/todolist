using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITodoListService
    {
        bool AddItem(Item item);
        Item GetItem(string itemName);
        List<Item> GetItems();
        bool GetItemsByPriority();
        bool ModifyItem();
        bool RemoveItem();
    }
}