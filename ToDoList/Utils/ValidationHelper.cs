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
            if (taskNames is null) return false;
            return taskNames.Any(x=>x== taskName);
        }

        public static bool TaskNameProfanityCheck(string taskName)
        {
            var list = new List<string> {"demo","world","hello","test" };

            return list.Any(x=>x== taskName);
        }
    }
}
