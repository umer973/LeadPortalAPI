using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Models
{
    public class Users
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string password { get; set; }
        public string isAdmin { get; set; }
        public string isActive { get; set; }
        public int dataVisibility { get; set; }

    }
}
