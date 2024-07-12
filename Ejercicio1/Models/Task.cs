using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio1.Models
{
    public class Task
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IsCompleted { get; set; }

        public string IsCompletedName { get; set; }

        
    }
}