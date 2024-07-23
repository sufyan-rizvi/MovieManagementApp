using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreManagementApp.Exceptions
{
    internal class CapacityFullException:Exception
    {
        public CapacityFullException(string message) : base(message)
        {
            
        }
    }
}
