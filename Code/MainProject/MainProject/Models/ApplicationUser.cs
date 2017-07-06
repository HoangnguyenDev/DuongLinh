using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MainProject.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string PictureSmall { get; set; }
        public string PictureBig { get; set; }
        public string DateofBirth { get; set; }
        public string Facebook { get; set; }
        public int Score { get; set; }
        public List<HistoryofRedingBook> HistoryofRedingBook { get; set; }
        public List<Message> Message { get; set; }
    }
}
