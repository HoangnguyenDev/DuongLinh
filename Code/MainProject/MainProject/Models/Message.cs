using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
