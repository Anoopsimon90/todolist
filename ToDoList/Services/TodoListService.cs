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

        static string filePath = @"C:\tmp\db.json";

        public TodoListService(ILogger<TodoListService> logger)
        {
            _logger = logger;
        }
        public Response AddItem(Item item)
        {
            
            if (ValidationHelper.TaskNameProfanityCheck(item.Name))
                return new Response
                {
                    Message = "Profanity check failed",
                    StatusCode = 0,
                    Timestamp = DateTime.Now
                };

            var taskExist = ValidationHelper.IsTaskNameExist(item.Name, GetItems()?.Select(x => x.Name).ToList());

            if (taskExist) return new Response
            {
                Message = "Taskname already exist",
                StatusCode = 0,
                Timestamp = DateTime.Now
            }; 

            try
            {
                var totalRecords = GetItems();
                var newRecordsList = (totalRecords?.Count == 0 || totalRecords is null) ? new List<Item>() : totalRecords;
                newRecordsList.Add(item);

                File.WriteAllText(filePath, JsonConvert.SerializeObject(newRecordsList));
            }
            catch (Exception e)
            {
                return new Response
                {
                    Message = e.StackTrace,
                    StatusCode = 0,
                    Timestamp = DateTime.Now
                }; 
            }

            return new Response
            {
                Message = "Success",
                StatusCode = 0,
                Timestamp = DateTime.Now
            }; ;
        }
        public bool RemoveItem() { return true; }
        public bool ModifyItem() { return true; }

        public Item GetItem(string itemName)
        {

            return GetItems()?.FirstOrDefault(i => i.Name == itemName);
        }

        public List<Item> GetItems()
        {
            FileInfo fileInfo = new FileInfo(filePath);

            //This code isn't really needed , but just to make a fake DB
            if (!fileInfo.Directory.Exists || !File.Exists(filePath) )
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
