using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date{ get; set; }
        public int Priority{ get; set; }
        public int Category{ get; set; }

    }
}
