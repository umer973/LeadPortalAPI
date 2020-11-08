using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Models
{
    public class Users
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string password { get; set; }
        public int isAdmin { get; set; }
        public int isActive { get; set; }
        public int dataVisibility { get; set; }

    }
}
