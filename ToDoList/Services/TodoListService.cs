using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDoList.Models;
using ToDoList.Utils;

namespace ToDoList.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ILogger _logger;

        static string filePath = @"C:/tmp/db.json";

        public TodoListService(ILogger<TodoListService> logger)
        {
            _logger = logger;
        }
        public bool AddItem(Item item)
        {
            // _logger.LogInformation("dsfdf");
            if (ValidationHelper.TaskNameProfanityCheck(item.Name)) return false;

            var taskExist = ValidationHelper.IsTaskNameExist(item.Name, GetItems()?.Select(x=>x.Name).ToList());

            if (taskExist) return false;

            try
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(item));
            }
            catch (Exception e)
            {
                return false;                
            }

            return true;
        }
        public bool RemoveItem() { return true; }
        public bool ModifyItem() { return true; }

        public Item GetItem(string itemName)
        {
            return GetItems()?.FirstOrDefault(i=>i.Name == itemName);            
        }

        public List<Item> GetItems()
        {
           FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
                File.CreateText(filePath).Close();
            }
            

            var content = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(content)) return null;

            return JsonConvert.DeserializeObject<List<Item>>(content);

        }
        public bool GetItemsByPriority() { return true; }
    }
}
