using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITodoListService
    {
        bool AddItem(Item item);
        Item GetItem();
        List<Item> GetItems();
        bool GetItemsByPriority();
        bool ModifyItem();
        bool RemoveItem();
    }
}