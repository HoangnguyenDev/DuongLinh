using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class BookChappter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [DisplayName("Đường dẫn")]
        public string Slug { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int BookCategoryID { get; set; }
        public BookCategory CategoryID { get; set; }

        public List<HistoryofRedingBook> HistoryofRedingBook { get; set; }
    }
}
