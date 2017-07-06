using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Message
    {
        public string ID { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
