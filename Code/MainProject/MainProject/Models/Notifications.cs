using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        
        public bool IsChapter { get; set; }

        public int BookChappterID { get; set; }
        public BookChappter BookChappter {get;set;}

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsReaded { get; set; }
        public bool Online { get; set; }
    }
}
