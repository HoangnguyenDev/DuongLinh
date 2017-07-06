using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class BookCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DisplayName("Tên sách")]
        public string CategoryName { get; set; }
        [DisplayName("Mô tả")]

        
        public string CategoryDes { get; set; }

        [DisplayName("Đường dẫn")]
        public string Slug { get; set; }
        public List<BookChappter> Chappters { get; set; }


    }
}
