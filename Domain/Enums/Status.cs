using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public class Status
    {
        public enum StatusTypes
        {
            Active = 0, //فعال
            Inactive = 1, //غیرفعال
            Suspended = 2 //تعلیق
        }
    }
}
