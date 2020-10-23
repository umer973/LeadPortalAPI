using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class BusinessData : IBusinessData
    {
        public Object objResult;

        public Int64 CreateUser()
        {
            return 1;
        }

        public object GetUsers()
        {
            objResult = null;
            objResult = "Users";
            return objResult;
        }
    }
}
