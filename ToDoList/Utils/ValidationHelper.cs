using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Utils
{
    public class ValidationHelper
    {
        public static bool IsTaskNameExist(string taskName,List<string> taskNames)
        {
            return taskNames.Contains(taskName) ? true : false;
        }
    }
}
